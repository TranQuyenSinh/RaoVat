using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace App.RequestModels;

public class AddressModel
{
    public AddressModel() { }
    public AddressModel(string province, string district, string ward, string address)
    {
        Province = province;
        District = district;
        Ward = ward;
        Address = address;
    }

    public string Address { get; set; }
    public string Province { get; set; }
    public string District { get; set; }
    public string Ward { get; set; }
}