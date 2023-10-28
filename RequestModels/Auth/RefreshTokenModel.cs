using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace App.RequestModels;

public class RefreshTokenModel
{
    public string AccessToken { get; set; }

    public string RefreshToken { get; set; }

}