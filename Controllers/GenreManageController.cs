using Microsoft.AspNetCore.Mvc;
using App.Models;
using App.Data;
using Microsoft.EntityFrameworkCore;
using App.Services;

namespace App.Controllers;

[ApiController]
[Route("api/genre-management")]
public class GenreManageController : ControllerBase
{
    private readonly ILogger<Test> _logger;
    private readonly AppDbContext _context;
    private readonly GenreService _genreService;

    public GenreManageController(ILogger<Test> logger, AppDbContext context, GenreService genreService)
    {
        _logger = logger;
        _context = context;
        _genreService = genreService;
    }



    [Route("genres")]
    public IActionResult Index(string? slug)
    {
        dynamic result;
        if (!string.IsNullOrEmpty(slug))
        {
            // genre with genreSlug
            result = _genreService.GetGenreBySlug(slug);
        }
        else
        {
            // parent genres
            result = _genreService.RootGenres();
        }

        return new JsonResult(result);
    }

    [HttpGet]
    public string Test()
    {
        return "test successfully";
    }
}
