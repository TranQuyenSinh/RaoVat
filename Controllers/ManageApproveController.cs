using Microsoft.AspNetCore.Mvc;
using App.Models;
using App.Data;
using App.Services;
using App.RequestModels;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SearchAdResponse = App.ResponseModels.SearchAdModel;
using SearchAdRequest = App.RequestModels.SearchAdModel;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using App.ResponseModels;
using App.Utils;

namespace App.Controllers;

[ApiController]
[Authorize]
[Route("api/manage-approve")]
public class ManageApproveController : ControllerBase
{
    private readonly AppDbContext _context;
    private readonly UserService _userService;
    private readonly IConfiguration _configuration;
    private readonly IEmailSender _emailSender;

    public ManageApproveController(AppDbContext context, UserService userService, IConfiguration configuration, IEmailSender emailSender)
    {
        _context = context;
        _userService = userService;
        _configuration = configuration;
        _emailSender = emailSender;
    }

    [HttpGet("waiting-approve-ads")]
    public async Task<IActionResult> GetWaitingApproveAds()
    {
        var waitingAds = await _context.Ads
        .Where(x => x.AprovedStatus == 0)
        .Include(x => x.Images)
                    .Select(x => new
                    {
                        Id = x.Id,
                        Title = x.Title,
                        Price = x.Price,
                        Status = x.Status,
                        Thumbnail = AppPath.GenerateImagePath(AppPath.AD_IMAGE, x.Images.FirstOrDefault().FileName),
                        CreatedAt = x.CreatedAt
                    })
                    .OrderBy(x => x.CreatedAt)
                    .ToListAsync();

        return new JsonResult(waitingAds);
    }


    [HttpGet("detail-ad")]
    public async Task<IActionResult> GetDetailAd(int adId)
    {
        var qr = _context.Ads
                .Where(x => x.Id == adId && x.AprovedStatus == 0)
                .Include(x => x.Images)
                .Include(x => x.AdGenre)
                .ThenInclude(x => x.Genre)
                .Include(x => x.Author)
                .AsSplitQuery()
                .Select(ad => new DetailAdModel(ad, null));

        return new JsonResult(qr.FirstOrDefault());
    }

    [HttpPut("approve-ad")]
    public async Task<IActionResult> ApproveAd(ApproveAdModel model)
    {
        var userId = _userService.GetUserId(User);
        var approvedUser = await _context.Users.FindAsync(userId);
        if (approvedUser == null) return NotFound("User not found");

        var ad = await _context.Ads
                    .Where(x => x.Id == model.AdId)
                    .Include(x => x.Author)
                    .FirstOrDefaultAsync();
        if (ad == null) return NotFound("Ad not found");
        _ = int.TryParse(_configuration["GlobalVariables:AdLifeTimeInDay"], out int AdLifeTimeInDay);

        ad.AprovedStatus = (byte)model.ApproveStatus;
        ad.AprovedAt = DateTime.Now;
        ad.AprovedUserId = approvedUser.Id;


        string? emailSubject;
        string? emailBody;
        if (ad.AprovedStatus == 2)
        {
            ad.RejectReason = model.RejectReason;
            (emailSubject, emailBody) = EmailUtils.GenerateRejectMail(ad);
        }
        else
        {
            (emailSubject, emailBody) = EmailUtils.GenerateApprovedMail(ad);
            ad.ExpireAt = DateTime.Now.AddDays(AdLifeTimeInDay);
        }

        await _context.SaveChangesAsync();
        await _emailSender.SendEmailAsync(ad.Author.Email, emailSubject, emailBody);

        return Ok("Ad has approved successfully");
    }


}
