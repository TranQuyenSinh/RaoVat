using System.ComponentModel.DataAnnotations;
namespace App.RequestModels;

public class EditRoleModel
{
    public int UserId { get; set; }
    public int RoleId { get; set; }

}