namespace App.RequestModels;

public class CreateBannerModel
{
    public IFormFile Image { get; set; }
    public string Description { get; set; }
    public string Url { get; set; }
}