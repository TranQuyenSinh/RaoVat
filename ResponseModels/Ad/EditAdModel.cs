using System.ComponentModel.DataAnnotations;
using App.Models;
using App.Utils;
namespace App.ResponseModels;

public class EditAdModel
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string Color { get; set; }
    public bool Status { get; set; }
    public int Price { get; set; }
    public string Origin { get; set; }
    public List<EditAd_Genre> Genres { get; set; }
    public List<EditAd_Image> Images { get; set; }

    public EditAdModel(Ad ad)
    {
        Id = ad.Id;
        Title = ad.Title;
        Description = ad.Description;
        Color = ad.Color;
        Origin = ad.Origin;
        Status = ad.Status;
        Price = ad.Price;
        Genres = ad.AdGenre.Select(x => new EditAd_Genre
        {
            Id = x.Genre.Id,
            Title = x.Genre.Title
        }).ToList();
        Images = ad.Images.Select(x => new EditAd_Image
        {
            Id = x.Id,
            Url = AppPath.GenerateImagePath(AppPath.AD_IMAGE, x.FileName)
        }).ToList();
    }
}

public class EditAd_Genre
{
    public int Id { get; set; }
    public string Title { get; set; }
}


public class EditAd_Image
{
    public int Id { get; set; }
    public string Url { get; set; }
}