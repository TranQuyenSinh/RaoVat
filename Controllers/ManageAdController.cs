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
    private readonly ManageAdService _manageAdService;

    public ManageAdController(ILogger<ManageAdController> logger, AppDbContext context, ManageAdService manageAdService)
    {
        _logger = logger;
        _context = context;
        _manageAdService = manageAdService;
    }

    [HttpGet("ads")]
    public async Task<IActionResult> Index(string type)
    {
        var userId = GetUserId();
        if (userId == -1) return Unauthorized("User not found");

        dynamic ads = new List<object>();
        switch (type)
        {
            case "display":
                ads = await _manageAdService.GetDisplayAds(userId);
                break;
            case "expired":
                ads = await _manageAdService.GetExpiredAds(userId);
                break;
            case "hidden":
                ads = await _manageAdService.GetHiddenAds(userId);
                break;
            case "waiting":
                ads = await _manageAdService.GetWaitingAds(userId);
                break;
            case "rejected":
                ads = await _manageAdService.GetRejectedAds(userId);
                break;
        }
        return new JsonResult(ads);
    }

    [HttpGet("handle")]
    public async Task<IActionResult> HandleAd(string type, int adId)
    {
        var userId = GetUserId();
        if (userId == -1) return Unauthorized("User not found");

        var result = false;
        switch (type)
        {
            case "show":
                result = await _manageAdService.HideAd(userId, adId, false);
                break;
            case "hide":
                result = await _manageAdService.HideAd(userId, adId, true);
                break;
            case "extend":
                result = await _manageAdService.ExtendAd(userId, adId);
                break;
            case "delete":
                result = await _manageAdService.DeleteAd(userId, adId);
                break;
        }

        return result ? Ok("Successfully") : BadRequest("Error has occurred, please try again!");
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
}
