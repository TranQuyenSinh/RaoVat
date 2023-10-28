using Microsoft.AspNetCore.Mvc;
using App.Models;
using App.Data;
using Microsoft.EntityFrameworkCore;
using App.Services;
using App.RequestModels;
using Microsoft.AspNetCore.Authorization;

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
    public IActionResult Index(
        string type,
        [FromQuery(Name = "i")] int? index,
        [FromQuery(Name = "p")] string? province,
        [FromQuery] string? genreSlug,
        [FromQuery(Name = "shopId")] int? shopId,
        int? adId)
    {
        IEnumerable<object> result = null;
        switch (type)
        {
            case "latest":
                result = _adService.GetCardAdsByProvince(index, province, genreSlug);
                break;
            case "related":
                result = _adService.GetCardAdsRelated(shopId);
                break;
            case "similar":
                result = _adService.GetCardAdsSimilar(adId);
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
    [Authorize]
    public IActionResult SaveAdToFavorite(SaveAdFavoriteModel model)
    {
        try
        {
            var user = _context.Users.Find(model.UserId);

            if (user == null)
                return NotFound("User not found");

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
            return Ok("Save to favorite list successfully");
        }
        catch (Exception e)
        {
            return BadRequest();
        }
    }


    [HttpPut("follow-shop")]
    [Authorize]
    public IActionResult FollowShop(FollowShopModel model)
    {
        try
        {
            var user = _context.Users.Find(model.UserId);
            var shop = _context.Users.Find(model.ShopId);

            if (user == null || shop == null)
            {
                return NotFound("User not found");
            }

            var followRecord = _context.User_Shop_Follow
            .Where(x => x.UserId == model.UserId && x.ShopId == model.ShopId)
            .FirstOrDefault();

            if (followRecord == null)
            {
                _context.User_Shop_Follow.Add(new User_Shop_Follow()
                {
                    UserId = model.UserId,
                    ShopId = model.ShopId
                });
            }
            else
            {
                _context.User_Shop_Follow.Remove(followRecord);
            }

            _context.SaveChanges();
            return Ok("Follow successfully");
        }
        catch (Exception e)
        {
            return BadRequest(e);
        }
    }

    [HttpGet]
    [Route("test")]
    public string Test()
    {
        return "test successfully";
    }
}
