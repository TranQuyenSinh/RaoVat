using App.Models;
using App.RequestModels;
using App.Utils;
using Bogus.DataSets;

namespace App.ResponseModels;
//  id: 3,
// title: 'Xe điện',
// thumbnail: 'https://localhost:8080/contents/ad/4tqc5jjs.o5y.jpg',
// price: 900000,
// status: 1,
// display: false,
// createAt: new Date(),
public class FavoriteAdModel
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Thumbnail { get; set; }
    public int Price { get; set; }
    public bool Status { get; set; }
    public bool Display { get; set; }
    public AddressModel Address { get; set; }
    public DateTime CreatedAt { get; set; }

    public FavoriteAdModel(Ad ad)
    {
        Id = ad.Id;
        Title = ad.Title;
        Price = ad.Price;
        Thumbnail = AppPath.GenerateImagePath(AppPath.AD_IMAGE, ad.Images?.FirstOrDefault()?.FileName);
        Status = ad.Status;
        CreatedAt = ad.CreatedAt;
        Display = ad.Display;
        Address = new AddressModel
        {
            Address = ad.Author.Address,
            District = ad.Author.District,
            Province = ad.Author.Province,
            Ward = ad.Author.Ward
        };
    }
}