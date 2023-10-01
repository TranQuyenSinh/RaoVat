namespace App.Utils;

public static class AppPath
{
    public static string GENRE_IMAGE_PATH = "/contents/genre/image/";
    public static string AD_IMAGE_PATH = "/contents/ad/";
    public static string USER_AVATAR_PATH = "/contents/customer/avatar/";

    public static string GenerateUserAvatarUrl(string? image)
    {
        if (string.IsNullOrEmpty(image))
            return null;

        return Environment
            .GetEnvironmentVariable("ASPNETCORE_APPLICATION_URL") +
            Path.Combine(USER_AVATAR_PATH, image);
    }
}