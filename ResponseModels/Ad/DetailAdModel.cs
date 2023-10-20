using App.Models;
using App.Utils;

namespace App.ResponseModels;

public class DetailAdModel
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public int Price { get; set; }
    public IEnumerable<string> Images { get; set; }
    public bool IsFavorite { get; set; }
    public string Status { get; set; }
    public string Color { get; set; }
    public string Origin { get; set; }
    public int ShopId { get; set; }
    public DateTime CreatedAt { get; set; }

    public DetailAdModel(Ad ad, int? userId = null)
    {
        Id = ad.Id;
        Title = ad.Title;
        Description = ad.Description;
        Price = ad.Price;
        Images = ad.Images?.Select(i => AppPath.GenerateImagePath(AppPath.AD_IMAGE, i.Image)).ToList();
        IsFavorite = userId.HasValue && ad.LikedUsers.Any(x => x.Id == userId.Value);
        Status = ad.Status ? "Mới" : "Cũ";
        Color = ad.Color;
        Origin = ad.Origin;
        ShopId = ad.Author.Id;
        CreatedAt = ad.CreatedAt;
    }
}