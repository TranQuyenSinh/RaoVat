using App.Models;
using App.Utils;

namespace App.ResponseModels;

public class ShopModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Phone { get; set; }
    public string District { get; set; }
    public string Province { get; set; }
    public int TotalFollowers { get; set; }
    public bool IsFollowed { get; set; }
    public string Avatar { get; set; }

    public ShopModel(User shop, int? userId = null)
    {
        Id = shop.Id;
        Name = shop.FullName;
        Phone = shop.Phone;
        District = shop.District;
        Province = shop.Province;
        TotalFollowers = shop.Followers.Count;
        IsFollowed = userId.HasValue && shop.Followers.Any(x => x.Id == userId.Value);
        Avatar = AppPath.GenerateImagePath(AppPath.USER_AVATAR, shop.Avatar);
    }
}