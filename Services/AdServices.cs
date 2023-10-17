using System.Drawing;
using App.Data;
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

    public IEnumerable<object> GetCardAdsByProvince(int? currentIndex, string province, int limit = 10)
    {
        var qr = _context.Ads
        .Include(x => x.Author)
        .Include(x => x.Images)
        .Select(x => new
        {
            Id = x.Id,
            Title = x.Title,
            Price = x.Price,
            Thumbnail = CombineImagePath(x.Images.FirstOrDefault().Image),
            District = x.Author.District,
            Province = x.Author.Province,
            CreatedAt = x.CreatedAt,
        });


        if (province != "Toàn quốc")
            qr = qr.Where(x => x.Province == province);

        var result = qr.Skip(currentIndex.Value * limit)
        .Take(limit)
        .OrderByDescending(x => x.CreatedAt)
        .ToList();

        return result;
    }
    public IEnumerable<object> GetCardAdsRelated(int? shopId, int limit = 10)
    {
        var qr = _context.Ads
        .Where(x => x.Author.Id == shopId)
        .Include(x => x.Author)
        .Include(x => x.Images)
        .Select(x => new
        {
            Id = x.Id,
            Title = x.Title,
            Price = x.Price,
            Thumbnail = CombineImagePath(x.Images.FirstOrDefault().Image),
            District = x.Author.District,
            Province = x.Author.Province,
            CreatedAt = x.CreatedAt,
        }).Take(limit).OrderByDescending(x => x.CreatedAt);

        return qr.ToList();
    }
    public IEnumerable<object> GetCardAdsSimilar(int? adId, int limit = 10)
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
        .Select(x => new
        {
            Id = x.Id,
            Title = x.Title,
            Price = x.Price,
            Thumbnail = CombineImagePath(x.Images.FirstOrDefault().Image),
            District = x.Author.District,
            Province = x.Author.Province,
            CreatedAt = x.CreatedAt,
        }).Take(limit);

        return qr.ToList();
    }

    public object GetDetailAd(int adId, int? userId = null)
    {
        var qr = _context.Ads
        .Where(x => x.Id == adId)
        .Include(x => x.Images)
        .Include(x => x.LikedUsers)
        .Include(x => x.Author)
        .ThenInclude(author => author.Followers)
        .Select(ad => new
        {
            Ad = new
            {
                Id = ad.Id,
                Title = ad.Title,
                Price = ad.Price,
                Description = ad.Description,
                Images = ad.Images.Select(ad => CombineImagePath(ad.Image)),
                IsFavorite = userId.HasValue ? ad.LikedUsers.Any(x => x.Id == userId.Value) : false,
                Status = ad.Status ? "Mới" : "Cũ",
                Color = ad.Color,
                Origin = ad.Origin,
                CreatedAt = ad.CreatedAt,
            },
            Shop = new
            {
                Id = ad.Author.Id,
                Name = ad.Author.FullName,
                Phone = ad.Author.Phone,
                District = ad.Author.District,
                Province = ad.Author.Province,
                TotalFollowers = ad.Author.Followers.Count(),
                IsFollowed = userId.HasValue ? ad.Author.Followers.Any(x => x.Id == userId.Value) : false
            }
        });

        return qr.FirstOrDefault();
    }

    public static string CombineImagePath(string image)
    {
        return image is not null ?
        Environment.GetEnvironmentVariable("ASPNETCORE_APPLICATION_URL") + Path.Combine(AppPath.AD_IMAGE_PATH, image) :
        null;
    }
}