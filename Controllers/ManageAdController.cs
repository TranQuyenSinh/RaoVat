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

namespace App.Controllers;

[ApiController]
[Route("api/manage-ad")]
[Authorize]
public class ManageAdController : ControllerBase
{
    private readonly ILogger<ManageAdController> _logger;
    private readonly AppDbContext _context;

    public ManageAdController(ILogger<ManageAdController> logger, AppDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    [HttpGet("display-ads")]
    public async Task<IActionResult> DisplayAds()
    {
        var userId = GetUserId();
        if (userId == -1) return Unauthorized("User not found");

        var displayAds = await _context.Ads
        .Where(x => x.AuthorId == userId
                && x.AprovedStatus == 1
                && x.Display == true
                && x.ExpireAt > DateTime.Now)
        .Include(x => x.Images)
        .Include(x => x.Author)
        .Include(x => x.UserAd)
        .AsSplitQuery()
        .OrderByDescending(x => x.CreatedAt)
        .Select(x => new DisplayAdModel(x))
        .ToListAsync();

        return new JsonResult(displayAds);
    }

    [HttpGet("hidden-ads")]
    public async Task<IActionResult> HiddenAds()
    {
        var userId = GetUserId();
        if (userId == -1) return Unauthorized("User not found");

        var hiddenAds = await _context.Ads
        .Where(x => x.AuthorId == userId
                && x.AprovedStatus == 1
                && x.Display == false
                && x.ExpireAt > DateTime.Now)
        .Include(x => x.Images)
        .Include(x => x.Author)
        .Include(x => x.UserAd)
        .AsSplitQuery()
        .OrderByDescending(x => x.CreatedAt)
        .Select(x => new DisplayAdModel(x))
        .ToListAsync();

        return new JsonResult(hiddenAds);
    }
    [HttpGet("expired-ads")]
    public async Task<IActionResult> ExpiredAds()
    {
        var userId = GetUserId();
        if (userId == -1) return Unauthorized("User not found");

        var expiredAds = await _context.Ads
        .Where(x => x.AuthorId == userId
                && x.AprovedStatus == 1
                && x.ExpireAt < DateTime.Now)
        .Include(x => x.Images)
        .Include(x => x.Author)
        .Include(x => x.UserAd)
        .AsSplitQuery()
        .OrderByDescending(x => x.ExpireAt)
        .Select(x => new DisplayAdModel(x))
        .ToListAsync();

        return new JsonResult(expiredAds);
    }

    // HideAd(3, true) => Hide ad with id = 3
    // HideAd(3, false) => Show ad with id = 3
    [HttpGet("hide-ad")]
    public async Task<IActionResult> HideAd(int adId, bool isHide)
    {
        var userId = GetUserId();
        if (userId == -1) return Unauthorized("User not found");

        var ad = await _context.Ads.Where(x => x.Id == adId && x.AuthorId == userId).FirstOrDefaultAsync();
        if (ad == null) return NotFound("Ad not found");

        ad.Display = !isHide;
        await _context.SaveChangesAsync();

        return Ok("Successfully");
    }

    [HttpGet("status-count")]
    public async Task<IActionResult> GetStatusAdCount()
    {
        var userId = GetUserId();
        if (userId == -1) return Unauthorized("User not found");

        var ads = await _context.Ads.Where(x => x.AuthorId == userId).ToListAsync();

        // đã kiểm duyệt và đang hiển thị
        var display = ads.Where(x => x.AprovedStatus == 1 && x.Display == true && x.ExpireAt > DateTime.Now).Count();

        // đã kiểm duyệt và đang ẩn
        var hidden = ads.Where(x => x.AprovedStatus == 1 && x.Display == false && x.ExpireAt > DateTime.Now).Count();

        // chờ duyệt
        var waiting = ads.Where(x => x.AprovedStatus == 0).Count();

        // đã bị từ chối
        var rejected = ads.Where(x => x.AprovedStatus == 2).Count();

        // đã hết hạn
        var expired = ads.Where(x => x.ExpireAt < DateTime.Now).Count();

        return new JsonResult(new
        {
            total = ads.Count,
            display,
            hidden,
            waiting,
            expired,
            rejected
        });

    }
    private int GetUserId()
    {
        var userIdClaim = User.Claims.Where(x => x.Type == ClaimTypes.Sid).FirstOrDefault().Value;
        if (!string.IsNullOrEmpty(userIdClaim))
        {
            return int.Parse(userIdClaim);
        }
        return -1;
    }
    [HttpGet]
    [Route("test")]
    public string Test()
    {
        return "test successfully";
    }
}
