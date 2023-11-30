using Microsoft.AspNetCore.Mvc;
using App.Models;
using App.Data;
using Microsoft.EntityFrameworkCore;
using App.Services;
using App.RequestModels;
using App.Utils;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Authorization;

namespace App.Controllers;

[ApiController]
[Route("api/user-view")]
public class UserViewController : ControllerBase
{
    private readonly ILogger<Test> _logger;
    private readonly AppDbContext _context;
    private readonly UserService _userService;

    public UserViewController(ILogger<Test> logger, AppDbContext context, UserService userService)
    {
        _logger = logger;
        _context = context;
        _userService = userService;
    }

    [HttpGet("detail-shop")]
    public IActionResult GetDetailShop(int shopId, int? userId = null)
    {
        return new JsonResult(_userService.GetDetailShop(shopId, userId));
    }

    [HttpPost("post-ad")]
    [Authorize]
    public IActionResult PostAd([FromForm] PostAdModel model)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest("Invalid input");
        }

        var userId = _userService.GetUserId(User);
        if (userId == -1) return NotFound("User not found");

        var newAd = new Ad()
        {
            AuthorId = userId,
            Title = model.Title,
            Description = model.Description,
            Color = model.Color,
            Origin = model.Origin,
            Status = model.Status == 1 ? true : false,
            Price = model.Price,
            CreatedAt = DateTime.Now,
        };
        // add genres
        model.GenreIds.ToList().ForEach(id =>
        {
            var genre = _context.Genres.Find(id);
            if (genre != null)
            {
                _context.AdGenre.Add(new AdGenre() { Genre = genre, Ad = newAd });
            }
        });

        // add images
        List<string> imageNames = CommonUtils.UploadImage(CommonUtils.AD_IMAGE, model.Images);
        var adImages = new List<AdImage>();
        imageNames.ForEach(name => adImages.Add(new AdImage() { FileName = name }));
        newAd.Images = adImages;

        try
        {
            _context.Ads.Add(newAd);
            _context.SaveChanges();
        }
        catch (Exception e)
        {
            return BadRequest("Lỗi dữ liệu, vui lòng thử lại!");
        }

        return Ok("Success!");
    }

}
