using App.Models;
using App.Utils;

namespace App.ResponseModels;

public class SearchAdModel
{
    public int Id { get; set; }
    public string Title { get; set; }
    public int Price { get; set; }
    public string Thumbnail { get; set; }
    public string District { get; set; }
    public string Province { get; set; }
    public bool IsFavorite { get; set; }
    public bool Status { get; set; }

    public DateTime CreatedAt { get; set; }
    public SearchAdModel(Ad ad, int? userId = null)
    {
        Id = ad.Id;
        Title = ad.Title;
        Price = ad.Price;
        Thumbnail = AppPath.GenerateImagePath(AppPath.AD_IMAGE, ad.Images?.FirstOrDefault()?.FileName);
        Status = ad.Status;
        District = ad.Author?.District;
        Province = ad.Author?.Province;
        CreatedAt = ad.CreatedAt;
        IsFavorite = userId.HasValue && ad.UserAd.Any(x => x.UserId == userId.Value);
    }
}