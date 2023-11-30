using System.ComponentModel.DataAnnotations;
namespace App.RequestModels;

public class PostAdModel
{
    public string Title { get; set; }
    public string Description { get; set; }
    public string Color { get; set; }
    public int Status { get; set; }
    public int Price { get; set; }
    public string Origin { get; set; }
    public int[] GenreIds { get; set; }
    public IFormFile[] Images { get; set; }

}