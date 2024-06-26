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
    public List<DetailAdGenre> Genres { get; set; }

    public DetailAdModel(Ad ad, int? userId = null)
    {
        Id = ad.Id;
        Title = ad.Title;
        Description = ad.Description;
        Price = ad.Price;
        Images = ad.Images?.Select(i => AppPath.GenerateImagePath(AppPath.AD_IMAGE, i.FileName)).ToList();
        Genres = ad.AdGenre?.Select(x => new DetailAdGenre(x.Genre)).ToList();
        IsFavorite = userId.HasValue && ad.UserAd.Any(x => x.UserId == userId.Value);
        Status = ad.Status ? "Mới" : "Cũ";
        Color = ad.Color;
        Origin = ad.Origin;
        ShopId = ad.Author.Id;
        CreatedAt = ad.CreatedAt;
    }
}

public class DetailAdGenre
{
    public int Id { get; set; }
    public string Title { get; set; }
    public DetailAdGenre(Genre genre)
    {
        Id = genre.Id;
        Title = genre.Title;
    }
}