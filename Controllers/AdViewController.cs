using Microsoft.AspNetCore.Mvc;
using App.Models;
using App.Data;
using Microsoft.EntityFrameworkCore;
using App.Services;

namespace App.Controllers;

[ApiController]
[Route("api/ad-view")]
public class AdViewController : ControllerBase
{
    private readonly ILogger<AdViewController> _logger;
    private readonly AppDbContext _context;
    private readonly AdServices _adService;

    public AdViewController(ILogger<AdViewController> logger, AppDbContext context, AdServices adService)
    {
        _logger = logger;
        _context = context;
        _adService = adService;
    }



    [Route("card-ads")]
    public IActionResult Index(string type, [FromQuery(Name = "i")] int currentIndex, [FromQuery(Name = "p")] string province)
    {
        IEnumerable<object> result = null;
        switch (type)
        {
            case "latest":
                result = _adService.GetCardAdsByProvince(currentIndex, province);
                break;

        }

        return new JsonResult(result);
    }

    [HttpGet]
    [Route("test")]
    public string Test()
    {
        return "test successfully";
    }
}
