using System.ComponentModel.DataAnnotations;
namespace App.RequestModels;

public class EditAdModel
{
    public int AdId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string Color { get; set; }
    public bool Status { get; set; }
    public int Price { get; set; }
    public string Origin { get; set; }
    public int[] GenreIds { get; set; }
    public IFormFile[]? AddImages { get; set; }
    public int[]? RemoveImages { get; set; }
}