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
        var userIdClaim = User.Claims.Where(x => x.Type == ClaimTypes.Sid).FirstOrDefault().Value;
        if (!string.IsNullOrEmpty(userIdClaim))
        {
            var userId = int.Parse(userIdClaim);
            var displayAds = await _context.Ads
            .Where(x => x.AuthorId == userId
                    && x.AprovedStatus == 1
                    && x.Display == true
                    && x.ExpireAt > DateTime.Now)
            .Include(x => x.Images)
            .Include(x => x.Author)
            .AsSplitQuery()
            .OrderByDescending(x => x.CreatedAt)
            .Select(x => new DisplayAdModel(x))
            .ToListAsync();
            return new JsonResult(displayAds);
        }

        return Unauthorized("User not found");
    }

    [HttpGet]
    [Route("test")]
    public string Test()
    {
        return "test successfully";
    }
}
