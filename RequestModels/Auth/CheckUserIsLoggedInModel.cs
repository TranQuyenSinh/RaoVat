using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace App.RequestModels;

public class CheckUserIsLoggedInModel
{
    public string AccessToken { get; set; }


}