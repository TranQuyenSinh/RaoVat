namespace App.RequestModels;

public class EditBannerModel
{
    public int Id { get; set; }
    public IFormFile? Image { get; set; }
    public string Description { get; set; }
    public string Url { get; set; }
}