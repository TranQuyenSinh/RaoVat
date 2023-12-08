using Microsoft.AspNetCore.Mvc;
using App.Models;
using App.Data;
using App.Services;
using App.RequestModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using App.Utils;
using App.ResponseModels;
namespace App.Controllers;

[ApiController]
[Route("api/banner")]
public class ManageBannerController : ControllerBase
{
    private readonly AppDbContext _context;
    private readonly UserService _userService;
    public ManageBannerController(AppDbContext context, UserService userService)
    {
        _context = context;
        _userService = userService;
    }

    [HttpGet]
    public async Task<IActionResult> GetDisplayBanners()
    {
        var banners = await _context.Banners
        .Where(x => x.Display == true)
        .Select(x => new DisplayBannerModel(x)).ToListAsync();
        return new JsonResult(banners);
    }

    [HttpGet("all")]
    [Authorize]
    public async Task<IActionResult> GetAllBanners()
    {
        var banners = await _context.Banners
        .Select(x => new BannerModel(x))
        .ToListAsync();
        return new JsonResult(banners);
    }

    [HttpPost("create")]
    [Authorize]
    public async Task<IActionResult> Create([FromForm] CreateBannerModel model)
    {
        var banner = new Banner
        {
            Url = model.Url,
            FileName = CommonUtils.UploadImage(CommonUtils.BANNER, new IFormFile[] { model.Image }).FirstOrDefault(),
            Description = model.Description,
            Display = model.Display,
            CreatedAt = DateTime.Now,
        };

        _context.Add(banner);
        await _context.SaveChangesAsync();
        return Ok("Save banner successfully");
    }

    [HttpPut("edit")]
    [Authorize]
    public async Task<IActionResult> Edit([FromForm] EditBannerModel model)
    {
        var banner = await _context.Banners.FindAsync(model.Id);
        if (banner == null) return NotFound("Banner not found");

        banner.Url = model.Url;
        banner.Description = model.Description;
        banner.Display = model.Display;
        if (model.Image != null)
        {
            CommonUtils.DeleteImage(CommonUtils.BANNER, banner.FileName);
            banner.FileName = CommonUtils.UploadImage(CommonUtils.BANNER, new IFormFile[] { model.Image }).FirstOrDefault();
        }
        await _context.SaveChangesAsync();
        return Ok("Save banner successfully");
    }

    [HttpDelete("delete")]
    [Authorize]
    public async Task<IActionResult> Delete(int id)
    {
        var banner = await _context.Banners.FindAsync(id);
        if (banner == null) return NotFound("Banner not found");

        CommonUtils.DeleteImage(CommonUtils.BANNER, banner.FileName);
        _context.Remove(banner);
        await _context.SaveChangesAsync();
        return Ok("Delete banner successfully");
    }
}
