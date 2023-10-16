using System.ComponentModel.DataAnnotations.Schema;

namespace App.Models;

public class User_Shop_Follow
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public int ShopId { get; set; }
}