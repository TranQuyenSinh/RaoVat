using System.ComponentModel.DataAnnotations;
namespace App.RequestModels;

public class SearchAdModel
{
    public string KeyWord { get; set; }
    public List<int>? Genres { get; set; } = new List<int>();
    public string? Order { get; set; }
    public List<int>? Prices { get; set; } = new List<int>();
    public string? Location { get; set; }
    public int? UserId { get; set; }
    public int CurrentPage { get; set; }

}