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

public class ManageAdService
{
    private readonly AppDbContext _context;
    private readonly ILogger<ManageAdService> _logger;

    public ManageAdService(AppDbContext context, ILogger<ManageAdService> logger)
    {
        _context = context;
        _logger = logger;
    }


    public async Task<List<ManageAdModel>> GetDisplayAds(int userId)
    {
        var displayAds = await _context.Ads
        .Where(x => x.AuthorId == userId
                && x.AprovedStatus == 1
                && x.Display == true
                && x.ExpireAt > DateTime.Now)
        .Include(x => x.Images)
        .Include(x => x.Author)
        .Include(x => x.UserAd)
        .AsSplitQuery()
        .OrderByDescending(x => x.CreatedAt)
        .Select(x => new ManageAdModel(x))
        .ToListAsync();

        return displayAds;
    }

    public async Task<List<ManageAdModel>> GetHiddenAds(int userId)
    {
        var hiddenAds = await _context.Ads
         .Where(x => x.AuthorId == userId
                 && x.AprovedStatus == 1
                 && x.Display == false
                 && x.ExpireAt > DateTime.Now)
         .Include(x => x.Images)
         .Include(x => x.Author)
         .Include(x => x.UserAd)
         .AsSplitQuery()
         .OrderByDescending(x => x.CreatedAt)
         .Select(x => new ManageAdModel(x))
         .ToListAsync();

        return hiddenAds;
    }

    public async Task<List<ManageAdModel>> GetExpiredAds(int userId)
    {
        var expiredAds = await _context.Ads
         .Where(x => x.AuthorId == userId
                 && x.AprovedStatus == 1
                 && x.ExpireAt < DateTime.Now)
         .Include(x => x.Images)
         .Include(x => x.Author)
         .Include(x => x.UserAd)
         .AsSplitQuery()
         .OrderByDescending(x => x.ExpireAt)
         .Select(x => new ManageAdModel(x))
         .ToListAsync();

        return expiredAds;
    }

    // HideAd(3, true) => Hide ad with id = 3
    // HideAd(3, false) => Show ad with id = 3
    public async Task<bool> HideAd(int userId, int adId, bool isHide)
    {
        var ad = await _context.Ads.Where(x => x.Id == adId && x.AuthorId == userId).FirstOrDefaultAsync();
        if (ad == null)
            return false;

        ad.Display = !isHide;
        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<bool> DeleteAd(int userId, int adId)
    {
        var ad = await _context.Ads.Where(x => x.Id == adId && x.AuthorId == userId).FirstOrDefaultAsync();
        if (ad == null)
            return false;

        _context.Ads.Remove(ad);
        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<bool> ExtendAd(int userId, int adId)
    {
        var ad = await _context.Ads
        .Where(x => x.Id == adId && x.AuthorId == userId && x.ExpireAt < DateTime.Now)
        .FirstOrDefaultAsync();
        if (ad == null)
            return false;

        ad.ExpireAt = DateTime.Now.AddDays(14);
        await _context.SaveChangesAsync();

        return true;
    }
}