using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace App.RequestModels;

public class SaveUserInfoModel
{
    public string FullName { get; set; }
    public string Email { get; set; }
    public string Description { get; set; }
    public string Phone { get; set; }
    public DateTime? DateOfBirth { get; set; }
    public bool? Gender { get; set; }
    public AddressModel Address { get; set; }

}