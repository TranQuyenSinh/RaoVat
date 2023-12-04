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

    public ManageApproveController(AppDbContext context)
    {
        _context = context;
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

    [HttpPut("edit-genre")]
    public async Task<IActionResult> SaveEditGenre([FromForm] EditGenreModel model)
    {
        var genre = await _context.Genres.FindAsync(model.Id);
        genre.Title = model.Title;
        genre.Description = model.Description;
        genre.Slug = GenerateGenreSlug(genre);
        if (model.Image != null)
        {
            CommonUtils.DeleteImage(CommonUtils.GENRE_IMAGE, genre.Image);
            genre.Image = CommonUtils.UploadImage(CommonUtils.GENRE_IMAGE, new IFormFile[] { model.Image })[0];
        }

        await _context.SaveChangesAsync();
        return Ok("Save change successfully");
    }

    [HttpPost("create-genre")]
    public async Task<IActionResult> CreateGenre([FromForm] CreateGenreModel model)
    {
        var genre = new Genre
        {
            Title = model.Title,
            Description = model.Description,
            ParentId = model.ParentId
        };
        genre.Slug = GenerateGenreSlug(genre);
        genre.Image = CommonUtils.UploadImage(CommonUtils.GENRE_IMAGE, new IFormFile[] { model.Image })[0];
        _context.Genres.Add(genre);
        await _context.SaveChangesAsync();
        return Ok("Create successfully");
    }

    [HttpDelete("delete-genre")]
    public async Task<IActionResult> DeleteGenre(int id)
    {
        var genre = await _context.Genres.Where(x => x.Id == id).Include(x => x.ChildrenGenres).FirstOrDefaultAsync();
        if (genre == null) return NotFound("Genre not found");

        if (genre.ChildrenGenres.Count != 0)
        {
            _context.Genres.RemoveRange(genre.ChildrenGenres);
        }

        _context.Genres.Remove(genre);
        await _context.SaveChangesAsync();
        return Ok("Create successfully");
    }

    [HttpGet]
    [Route("test")]
    public string Test()
    {
        return "test successfully";
    }

    private string GenerateGenreSlug(Genre genre)
    {
        var counter = 1;
        var prefix = "";
        var slug = CommonUtils.GenerateSlug(genre.Title);
        while (_context.Genres.Any(x => x.Slug == slug + prefix && x.Id != genre.Id))
        {
            prefix = "-" + counter.ToString();
            counter++;
        }
        return slug + prefix;
    }
}
