using System.ComponentModel.DataAnnotations;
namespace App.RequestModels;

public class CreateGenreModel
{
    public string Title { get; set; }
    public string Description { get; set; }
    public IFormFile Image { get; set; }
}