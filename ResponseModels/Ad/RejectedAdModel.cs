using App.Models;
using App.Utils;

namespace App.ResponseModels;

public class RejectedAdModel
{
    public int Id { get; set; }
    public string Title { get; set; }
    public int Price { get; set; }
    public string Thumbnail { get; set; }
    public string District { get; set; }
    public string Province { get; set; }
    public string RejectReason { get; set; }


    public RejectedAdModel(Ad ad)
    {
        Id = ad.Id;
        Title = ad.Title;
        Price = ad.Price;
        Thumbnail = AppPath.GenerateImagePath(AppPath.AD_IMAGE, ad.Images?.FirstOrDefault()?.FileName);
        RejectReason = ad.RejectReason;
        District = ad.Author?.District;
        Province = ad.Author?.Province;
    }
}