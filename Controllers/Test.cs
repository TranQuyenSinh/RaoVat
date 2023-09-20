using Microsoft.AspNetCore.Mvc;
using App.Models;
using App.Data;

namespace App.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class Test : ControllerBase
{
    private readonly ILogger<Test> _logger;
    private readonly AppDbContext _dbContext;

    public Test(ILogger<Test> logger, AppDbContext dbContext)
    {
        _logger = logger;
        _dbContext = dbContext;
    }

    // [HttpGet]
    // public void InitDb()
    // {

    //     _dbContext.AllType.Add(new AllType()
    //     {
    //         Type = "ROLE",
    //         TypeKey = "R1",
    //         TypeName = "Administrator",
    //     });
    //     _dbContext.SaveChanges();
    // }

    // [HttpGet]
    // public IEnumerable<AllType> CheckDb()
    // {
    //     return _dbContext.AllType.ToArray();

    // }

    // public IActionResult DeleteType(int? id)
    // {
    //     var item = _dbContext.AllType.Find(id);
    //     if (item == null)
    //     {
    //         return NotFound();
    //     }

    //     _dbContext.AllType.Remove(item);
    //     _dbContext.SaveChanges();
    //     return Ok("Remove sucessfully");

    // }

    // [HttpGet]
    // public IEnumerable<WeatherForecast> Get()
    // {
    //     return Enumerable.Range(1, 5).Select(index => new WeatherForecast
    //     {
    //         Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
    //         TemperatureC = Random.Shared.Next(-20, 55),
    //         Summary = Summaries[Random.Shared.Next(Summaries.Length)]
    //     })
    //     .ToArray();
    // }
}
