using App.Models;
using App.Utils;

namespace App.ResponseModels;

public class DisplayAdModel
{
    public int Id { get; set; }
    public string Title { get; set; }
    public int Price { get; set; }
    public string Thumbnail { get; set; }
    public string District { get; set; }
    public string Province { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime ExpireAt { get; set; }


    public DisplayAdModel(Ad ad)
    {
        Id = ad.Id;
        Title = ad.Title;
        Price = ad.Price;
        Thumbnail = AppPath.GenerateImagePath(AppPath.AD_IMAGE, ad.Images?.FirstOrDefault()?.FileName);
        District = ad.Author?.District;
        Province = ad.Author?.Province;
        CreatedAt = ad.CreatedAt;
        ExpireAt = ad.ExpireAt;
    }
}