using Microsoft.AspNetCore.Mvc;
using App.Models;
using App.Data;
using Microsoft.EntityFrameworkCore;
using App.Services;
using App.RequestModels;

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

    [HttpGet("card-ads")]
    public IActionResult Index(string type, [FromQuery(Name = "i")] int? currentIndex, [FromQuery(Name = "p")] string? province, [FromQuery(Name = "shopId")] int? shopId)
    {
        IEnumerable<object> result = null;
        switch (type)
        {
            case "latest":
                result = _adService.GetCardAdsByProvince(currentIndex, province);
                break;
            case "related":
                result = _adService.GetCardAdsRelated(shopId);
                break;
        }

        return new JsonResult(result);
    }

    [HttpGet("detail-ad")]
    public IActionResult DetailAd(int id, int? userId = null)
    {
        var result = _adService.GetDetailAd(id, userId);
        return new JsonResult(result);
    }

    [HttpPut("save-ad-to-favorite")]
    public IActionResult SaveAdToFavorite(SaveAdFavoriteModel model)
    {
        try
        {
            var user = _context.Users.Find(model.UserId);

            if (user == null)
                throw new Exception();

            var favorite_record = _context.User_Ad_Favorite.Where(x => x.UserId == model.UserId && x.AdId == model.AdId).FirstOrDefault();
            if (favorite_record == null)
            {
                _context.User_Ad_Favorite.Add(new User_Ad_Favorite()
                {
                    UserId = model.UserId,
                    AdId = model.AdId
                });
            }
            else
            {
                _context.User_Ad_Favorite.Remove(favorite_record);
            }

            _context.SaveChanges();
            return Ok();
        }
        catch (Exception e)
        {
            return BadRequest();
        }
    }

    [HttpGet]
    [Route("test")]
    public string Test()
    {
        return "test successfully";
    }
}
