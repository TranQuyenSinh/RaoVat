using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace App.RequestModels;

public class RegisterModel
{
    [StringLength(255, ErrorMessage = "Họ tên không hợp lệ", MinimumLength = 3)]
    public string FullName { get; set; }

    [EmailAddress(ErrorMessage = "Email không hợp lệ")]
    public string Email { get; set; }

    [StringLength(255, ErrorMessage = "Mật khẩu phải từ 6 ký tự trở lên", MinimumLength = 6)]
    public string Password { get; set; }
}