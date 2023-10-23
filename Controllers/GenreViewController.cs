using Microsoft.AspNetCore.Mvc;
using App.Models;
using App.Data;
using Microsoft.EntityFrameworkCore;
using App.Services;

namespace App.Controllers;

[ApiController]
[Route("api/genre-view")]
public class GenreViewController : ControllerBase
{
    private readonly ILogger<Test> _logger;
    private readonly AppDbContext _context;
    private readonly GenreService _genreService;

    public GenreViewController(ILogger<Test> logger, AppDbContext context, GenreService genreService)
    {
        _logger = logger;
        _context = context;
        _genreService = genreService;
    }

    [HttpGet("all-genres")]
    public IActionResult Index()
    {
        return new JsonResult(_genreService.GetAllGenres());
    }

    [HttpGet("root")]
    public IActionResult GetRootGenres()
    {
        return new JsonResult(_genreService.RootGenres());
    }

    [HttpGet("{slug?}")]
    public IActionResult GetGenrebySlug(string slug)
    {
        return new JsonResult(_genreService.GetGenreBySlug(slug));
    }

}
