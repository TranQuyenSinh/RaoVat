using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace App.RequestModels;

public class ChangeUserPasswordModel
{
    public string CurrentPassword { get; set; }
    public string NewPassword { get; set; }
}