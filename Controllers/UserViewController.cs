using Microsoft.AspNetCore.Mvc;
using App.Models;
using App.Data;
using Microsoft.EntityFrameworkCore;
using App.Services;
using App.RequestModels;
using App.Utils;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Authorization;
using App.ResponseModels;

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

    [HttpGet("get-edit-ad")]
    [Authorize]
    public async Task<IActionResult> GetEditAd(int adId)
    {
        var userId = _userService.GetUserId(User);
        if (userId == -1) return NotFound("User not found");

        var editAd = await _context.Ads
                            .Where(x => x.Id == adId && x.AuthorId == userId)
                            .Include(x => x.Images)
                            .Include(x => x.Author)
                            .Include(x => x.AdGenre)
                            .ThenInclude(x => x.Genre)
                            .FirstOrDefaultAsync();
        if (editAd == null) return NotFound("Ad not found");

        var model = new ResponseModels.EditAdModel(editAd);

        return new JsonResult(model);
    }

    [HttpPost("save-edit-ad")]
    [Authorize]
    public async Task<IActionResult> SaveEditAd([FromForm] RequestModels.EditAdModel ad)
    {
        var userId = _userService.GetUserId(User);
        if (userId == -1) return NotFound("User not found");

        var editAd = await _context.Ads
                            .Where(x => x.Id == ad.AdId && x.AuthorId == userId)
                            .Include(x => x.Images)
                            .Include(x => x.AdGenre)
                            .ThenInclude(x => x.Genre)
                            .FirstOrDefaultAsync();
        if (editAd == null) return NotFound("Ad not found");

        // ad info
        editAd.Title = ad.Title;
        editAd.Description = ad.Description;
        editAd.Price = ad.Price;
        editAd.Status = ad.Status;
        editAd.Color = ad.Color;
        editAd.Origin = ad.Origin;
        editAd.AprovedStatus = 0;

        // genre
        _context.AdGenre.RemoveRange(_context.AdGenre.Where(x => x.AdId == editAd.Id).ToList());
        var addGenres = await _context.Genres.Where(x => ad.GenreIds.Contains(x.Id)).ToListAsync();
        addGenres.ForEach(genre => _context.Add(new AdGenre
        {
            AdId = editAd.Id,
            GenreId = genre.Id
        }));

        // remove images
        if (ad.RemoveImages?.Length > 0)
        {
            var deleteImages = await _context.AdImages.Where(x => x.AdId == editAd.Id && ad.RemoveImages.Contains(x.Id)).ToListAsync();
            deleteImages.ForEach(image => CommonUtils.DeleteImage(CommonUtils.AD_IMAGE, image.FileName));
            _context.AdImages.RemoveRange(deleteImages);
        }

        // add images
        if (ad.AddImages?.Length > 0)
        {
            List<string> imageNames = CommonUtils.UploadImage(CommonUtils.AD_IMAGE, ad.AddImages);
            var newImages = new List<AdImage>();
            imageNames.ForEach(name => newImages.Add(new AdImage() { AdId = editAd.Id, FileName = name }));
            await _context.AdImages.AddRangeAsync(newImages);
        }

        await _context.SaveChangesAsync();
        return Ok("Save successfully");
    }

}
