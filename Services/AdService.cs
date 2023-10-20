using System.Drawing;
using App.Data;
using App.Models;
using App.ResponseModels;
using App.Utils;
using Microsoft.EntityFrameworkCore;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace App.Services;

public class AdServices
{
    private readonly AppDbContext _context;
    private readonly IHostingEnvironment _env;
    private readonly ILogger<AdServices> _logger;


    public AdServices(AppDbContext context, IHostingEnvironment env, ILogger<AdServices> logger)
    {
        _context = context;
        _env = env;
        _logger = logger;
    }

    public ICollection<AdCardModel> GetCardAdsByProvince(int? currentIndex, string province, int limit = 10)
    {
        var qr = _context.Ads
        .Include(x => x.Author)
        .Include(x => x.Images)
        .AsQueryable();

        if (province != "Toàn quốc")
            qr = qr.Where(x => x.Author.Province == province);

        var result = qr.Skip(currentIndex.Value * limit)
                        .Take(limit)
                        .OrderByDescending(x => x.CreatedAt)
                        .Select(ad => new AdCardModel(ad))
                        .ToList();

        return result;
    }
    public ICollection<AdCardModel> GetCardAdsRelated(int? shopId, int limit = 10)
    {
        var qr = _context.Ads
        .Include(x => x.Author)
        .Include(x => x.Images)
        .Where(x => x.Author.Id == shopId)
        .OrderByDescending(x => x.CreatedAt)
        .Select(ad => new AdCardModel(ad))
        .Take(limit);

        return qr.ToList();
    }
    public ICollection<AdCardModel> GetCardAdsSimilar(int? adId, int limit = 10)
    {
        var ad = _context.Ads.Include(x => x.Genres).FirstOrDefault(x => x.Id == adId.Value);
        if (ad == null)
            return null;

        var qr = _context.Ads
        .Include(x => x.Genres)
        .Include(x => x.Author)
        .Include(x => x.Images)
        .Where(x => x.Genres.All(genre => ad.Genres.Contains(genre)))
        .OrderByDescending(x => x.Genres.Count)
        .Select(ad => new AdCardModel(ad)).Take(limit);

        return qr.ToList();
    }

    public DetailAdModel GetDetailAd(int adId, int? userId = null)
    {
        var qr = _context.Ads
        .Where(x => x.Id == adId)
        .Include(x => x.Images)
        .Include(x => x.LikedUsers)
        .Include(x => x.Author)
        .ThenInclude(author => author.Followers)
        .Select(ad => new DetailAdModel(ad, userId));

        return qr.FirstOrDefault();
    }



}