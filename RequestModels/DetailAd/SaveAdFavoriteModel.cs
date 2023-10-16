using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace App.RequestModels;

public class SaveAdFavoriteModel
{
    public int UserId { get; set; }
    public int AdId { get; set; }
}