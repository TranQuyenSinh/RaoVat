using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.VisualBasic;

namespace App.Utils;

public static class CommonUtils
{
    public static List<string> UploadImage(IFormFile[] files)
    {
        List<string> fileNames = new List<string>();
        foreach (var image in files)
        {
            string imgName = null;
            if (image != null)
            {
                imgName = Path.GetFileName(Path.GetRandomFileName()) + Path.GetExtension(image.FileName);
                var uploadPath = Path.Combine(AppPath.AD_IMAGE_FOLDER, imgName);

                // resize the image
                // var width = Const.STORY_THUMB_WIDTH;
                // var height = Const.STORY_THUMB_HEIGHT;
                // Image img = Image.FromStream(file.OpenReadStream());
                // var cutImg = new Bitmap(img, width, height);

                try
                {
                    using (var fs = new FileStream(uploadPath, FileMode.Create))
                    {
                        image.CopyTo(fs);
                        fileNames.Add(imgName);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error when uploading the file: {0}", image.FileName);
                    Console.WriteLine("Error message: {0}", e.Message);
                }
            }
        }

        return fileNames;
    }
}