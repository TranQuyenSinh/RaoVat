namespace App.Utils;

public static class AppPath
{
    public const string GENRE_IMAGE = "/contents/genre/image/";
    public const string AD_IMAGE = "/contents/ad/";
    public const string USER_AVATAR = "/contents/customer/avatar/";

    public const string AD_IMAGE_FOLDER = "Uploads/Ad/";

    public static string GenerateImagePath(string type, string? image)
    {
        if (string.IsNullOrEmpty(image))
            return null;

        string rootPath = Environment.GetEnvironmentVariable("ASPNETCORE_APPLICATION_URL");
        string imagePath = Path.Combine(type, image);

        return rootPath + imagePath;
    }
}