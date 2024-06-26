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

namespace App.Controllers;

[ApiController]
[Route("api/ad-view")]
public class AdViewController : ControllerBase
{
    private readonly ILogger<AdViewController> _logger;
    private readonly AppDbContext _context;
    private readonly AdServices _adService;
    private readonly UserService _userService;

    public AdViewController(ILogger<AdViewController> logger, AppDbContext context, AdServices adService, UserService userService)
    {
        _logger = logger;
        _context = context;
        _adService = adService;
        _userService = userService;
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

    [HttpPost("search-ad")]
    public IActionResult SearchAd([FromBody] SearchAdRequest model)
    {
        var (result, totalCount) = _adService.SearchAds(model, model.CurrentPage);

        return new JsonResult(new
        {
            data = result,
            currentPage = model.CurrentPage,
            totalCount,
        });
    }

    [HttpPut("save-ad-to-favorite")]
    [Authorize]
    public IActionResult SaveAdToFavorite(SaveAdFavoriteModel model)
    {
        try
        {
            var userId = _userService.GetUserId(User);
            if (userId == -1) return NotFound("User not found");

            var favorite_record = _context.User_Ad_Favorite.Where(x => x.UserId == userId && x.AdId == model.AdId).FirstOrDefault();
            if (favorite_record == null)
            {
                _context.User_Ad_Favorite.Add(new User_Ad_Favorite()
                {
                    UserId = userId,
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
            var userId = _userService.GetUserId(User);
            var user = _context.Users.Find(userId);
            var shop = _context.Users.Find(model.ShopId);

            if (user == null || shop == null)
            {
                return NotFound("User not found");
            }

            var followRecord = _context.User_Shop_Follow
            .Where(x => x.UserId == userId && x.ShopId == model.ShopId)
            .FirstOrDefault();

            if (followRecord == null)
            {
                _context.User_Shop_Follow.Add(new User_Shop_Follow()
                {
                    UserId = user.Id,
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
