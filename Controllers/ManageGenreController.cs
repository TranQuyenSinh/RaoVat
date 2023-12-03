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
[Route("api/manage-genre")]
public class ManageGenreController : ControllerBase
{
    private readonly ILogger<ManageGenreController> _logger;
    private readonly AppDbContext _context;
    private readonly GenreService _genreService;

    public ManageGenreController(ILogger<ManageGenreController> logger, AppDbContext context, GenreService genreService)
    {
        _logger = logger;
        _context = context;
        _genreService = genreService;
    }

    [HttpPost("create-genre")]
    [Authorize]
    public async Task<IActionResult> CreateGenre([FromForm] CreateGenreModel model)
    {
        var genre = new Genre
        {
            Title = model.Title,
            Description = model.Description
        };
        genre.Slug = GenerateGenreSlug(genre);
        genre.Image = CommonUtils.UploadImage(CommonUtils.GENRE_IMAGE, new IFormFile[] { model.Image })[0];
        _context.Genres.Add(genre);
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
