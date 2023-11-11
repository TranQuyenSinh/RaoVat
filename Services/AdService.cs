using System.Drawing;
using App.Data;
using App.Models;
using App.ResponseModels;
using App.Utils;
using Microsoft.EntityFrameworkCore;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;
using SearchAdResponse = App.ResponseModels.SearchAdModel;
using SearchAdRequest = App.RequestModels.SearchAdModel;
using Microsoft.AspNetCore.Mvc;
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


    public ICollection<AdCardModel> GetCardAdsByProvince(int? index, string province, string genreSlug, int limit = 10)

    {
        var qr = _context.Ads
        .Include(x => x.Author)
        .Include(x => x.Images)
        .AsQueryable();

        if (province != "Toàn quốc")
            qr = qr.Where(x => x.Author.Province == province);

        if (!string.IsNullOrEmpty(genreSlug))
        {
            var genre = _context.Genres.Where(x => x.Slug == genreSlug).FirstOrDefault();

            if (genre != null)
            {
                qr = qr.Include(x => x.AdGenre)
                        .Where(x => x.AdGenre.Any(ag => ag.GenreId == genre.Id));
            }
        }

        var result = qr.OrderByDescending(x => x.CreatedAt)
                        .Skip(index.Value * limit)
                        .Take(limit)

                        .Select(ad => new AdCardModel(ad))
                        .ToList();

        return result;
    }
    public ICollection<AdCardModel> GetCardAdsRelated(int? shopId, int limit = 10)
    {
        var qr = _context.Ads
        .Where(x => x.AuthorId == shopId)
        .Include(x => x.Author)
        .Include(x => x.Images)
        .AsSplitQuery()
        .OrderByDescending(x => x.CreatedAt)
        .Select(ad => new AdCardModel(ad))
        .Take(limit);

        return qr.ToList();
    }
    public ICollection<AdCardModel> GetCardAdsSimilar(int? adId, int limit = 10)
    {

        var ad = _context.Ads
                .Include(x => x.AdGenre)
                .ThenInclude(x => x.Genre)
                .FirstOrDefault(x => x.Id == adId.Value);

        if (ad == null)
            return null;

        var qr = _context.Ads
        .Include(x => x.AdGenre)
        .Where(x => x.AdGenre.All(genre => ad.AdGenre.Contains(genre)))
        .Include(x => x.Author)
        .Include(x => x.Images)
        .AsSplitQuery()
        .OrderByDescending(x => x.AdGenre.Count)

        .Select(ad => new AdCardModel(ad)).Take(limit);

        return qr.ToList();
    }

    public DetailAdModel GetDetailAd(int adId, int? userId = null)
    {
        var qr = _context.Ads
        .Where(x => x.Id == adId)
        .Include(x => x.Images)
        .Include(x => x.UserAd)
        .Include(x => x.Author)
        .ThenInclude(author => author.Followers)
        .Select(ad => new DetailAdModel(ad, userId));

        return qr.FirstOrDefault();
    }

    public (ICollection<SearchAdResponse>, int) SearchAds(SearchAdRequest model, int currentPage = 0, int itemCount = 10)
    {
        List<SearchAdResponse> result = null;

        var qr = _context.Ads.Where(x => x.Title.Contains(model.KeyWord))
         .Include(x => x.Author)
         .Include(x => x.AdGenre)
         .Include(x => x.UserAd)
         .Include(x => x.Images)
         .AsSingleQuery();


        if (model.Location != "Toàn quốc")
        {
            qr = qr.Where(x => x.Author.Province == model.Location);
        }

        if (model.Genres?.Count > 0)
        {
            qr = qr.Where(x => x.AdGenre.All(adGenre => model.Genres.Contains(adGenre.GenreId)));
        }

        if (model.Prices?.Count > 0)
        {
            qr = qr.Where(x => x.Price <= model.Prices[1] && x.Price >= model.Prices[0]);
        }

        if (!string.IsNullOrEmpty(model.Order))
        {
            if (model.Order == "price")
                qr = qr.OrderBy(x => x.Price);
            else if (model.Order == "createdAt")
                qr = qr.OrderByDescending(x => x.CreatedAt);
        }

        var totalCount = qr.Count();

        qr = qr.Skip(currentPage * itemCount).Take(itemCount);
        result = qr.Select(x => new SearchAdResponse(x, model.UserId)).ToList();

        return (result, totalCount);
    }



}