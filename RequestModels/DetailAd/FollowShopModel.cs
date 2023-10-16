using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace App.RequestModels;

public class FollowShopModel
{
    public int UserId { get; set; }
    public int ShopId { get; set; }
}