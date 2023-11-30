using System.Security.Claims;
using App.Data;
using App.Models;
using App.ResponseModels;
using App.Utils;
using Microsoft.EntityFrameworkCore;

namespace App.Services;

public class UserService
{
    private readonly AppDbContext _context;
    public UserService(AppDbContext context)
    {
        _context = context;
    }

    public ShopModel GetDetailShop(int shopId, int? userId = null)
    {
        var qr = _context.Users
       .Where(x => x.Id == shopId)
       .Include(x => x.Followers)
       .Select(shop => new ShopModel(shop, userId));

        return qr.FirstOrDefault();
    }
    public int GetUserId(ClaimsPrincipal User)
    {
        var userIdClaim = User.Claims.Where(x => x.Type == ClaimTypes.Sid).FirstOrDefault().Value;
        if (!string.IsNullOrEmpty(userIdClaim))
        {
            return int.Parse(userIdClaim);
        }
        return -1;
    }
}