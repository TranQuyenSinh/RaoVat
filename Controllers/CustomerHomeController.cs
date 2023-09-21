using Microsoft.AspNetCore.Mvc;
using App.Models;
using App.Data;

namespace App.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class CustomerHomeController : ControllerBase
{
    private readonly ILogger<Test> _logger;
    private readonly AppDbContext _context;

    public CustomerHomeController(ILogger<Test> logger, AppDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    [HttpGet]
    public IEnumerable<object> GetParentGenres()
    {
        Thread.Sleep(2000);
        return _context.Genres
        .Where(x => x.Parent == null)
        .Select(x => new { id = x.Id, title = x.Title, image = x.Image, }).ToArray();
    }

    public string TestApi()
    {
        return "Test api successfully";
    }
}
