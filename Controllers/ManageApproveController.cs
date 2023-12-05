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

    public ManageApproveController(AppDbContext context, UserService userService, IConfiguration configuration)
    {
        _context = context;
        _userService = userService;
        _configuration = configuration;
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

    [HttpPut("approve-ad")]
    public async Task<IActionResult> ApproveAd(ApproveAdModel model)
    {
        var userId = _userService.GetUserId(User);
        if (userId == -1) return NotFound("User not found");

        var ad = await _context.Ads.FindAsync(model.AdId);
        if (ad == null) return NotFound("Ad not found");

        _ = int.TryParse(_configuration["GlobalVariables:AdLifeTimeInDay"], out int AdLifeTimeInDay);

        ad.AprovedStatus = (byte)model.ApproveStatus;
        ad.AprovedAt = DateTime.Now;
        ad.AprovedUserId = userId;

        if (ad.AprovedStatus == 2)
        {
            ad.RejectReason = model.RejectReason;
        }
        else
        {
            ad.ExpireAt = DateTime.Now.AddDays(AdLifeTimeInDay);
        }

        await _context.SaveChangesAsync();

        return Ok("Ad has approved successfully");
    }


}
