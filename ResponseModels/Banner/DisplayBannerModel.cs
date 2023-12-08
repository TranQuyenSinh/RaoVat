using App.Models;
using App.Utils;
using Server.Migrations;
using Banner = App.Models.Banner;

namespace App.ResponseModels;

public class DisplayBannerModel
{
    public int Id { get; set; }
    public string Image { get; set; }
    public string Url { get; set; }

    public DisplayBannerModel(Banner banner)
    {
        Id = banner.Id;
        Image = AppPath.GenerateImagePath(AppPath.BANNER, banner.FileName);
        Url = banner.Url;
    }
}

public class BannerModel
{
    public int Id { get; set; }
    public string Image { get; set; }
    public string Url { get; set; }
    public string Description { get; set; }
    public bool Display { get; set; }
    public DateTime CreatedAt { get; set; }
    public BannerModel(Banner banner)
    {
        Id = banner.Id;
        Description = banner.Description;
        Image = AppPath.GenerateImagePath(AppPath.BANNER, banner.FileName);
        Url = banner.Url;
        Display = banner.Display;
        CreatedAt = banner.CreatedAt;
    }
}