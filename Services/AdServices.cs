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

    public IEnumerable<object> GetCardAdsByProvince(int currentIndex, string province, int limit = 10)
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

        var result = qr.Skip(currentIndex * limit)
        .Take(limit)
        .OrderByDescending(x => x.CreatedAt)
        .ToList();

        return result;
    }

    public static string CombineImagePath(string image)
    {
        return image is not null ?
        Environment.GetEnvironmentVariable("ASPNETCORE_APPLICATION_URL") + Path.Combine(AppPath.AD_IMAGE_PATH, image) :
        null;
    }
}