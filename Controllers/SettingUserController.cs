using Microsoft.AspNetCore.Mvc;
using App.Models;
using App.Data;
using App.Services;
using App.RequestModels;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SearchAdResponse = App.ResponseModels.SearchAdModel;
using SearchAdRequest = App.RequestModels.SearchAdModel;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using App.ResponseModels;
using App.Utils;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.CodeAnalysis.Elfie.Model;

namespace App.Controllers;

[ApiController]
[Route("api/user-settings")]
[Authorize]
public class SettingUserController : ControllerBase
{
    private readonly ILogger<SettingUserController> _logger;
    private readonly AppDbContext _context;
    private readonly UserService _userService;

    public SettingUserController(ILogger<SettingUserController> logger, AppDbContext context, UserService userService)
    {
        _logger = logger;
        _context = context;
        _userService = userService;
    }

    [HttpGet("user-info")]
    public async Task<IActionResult> GetUserInfo()
    {
        var userId = _userService.GetUserId(User);
        if (userId == -1) return Unauthorized("User not found");

        var user = await _context.Users
        .Where(x => x.Id == userId)
        .Select(x => new
        {
            x.FullName,
            x.Phone,
            x.Description,
            x.Email,
            x.Gender,
            x.DateOfBirth,
            Address = new { x.Address, x.Ward, x.Province, x.District },
            Avatar = AppPath.GenerateImagePath(AppPath.USER_AVATAR, x.Avatar)
        }).FirstOrDefaultAsync();

        if (user == null) return NotFound();

        return new JsonResult(user);
    }

    [HttpPost("user-info")]
    public async Task<IActionResult> SaveUserInfo(SaveUserInfoModel model)
    {
        var userId = _userService.GetUserId(User);
        if (userId == -1) return Unauthorized("User not found");

        var user = await _context.Users
        .Where(x => x.Id == userId)
        .FirstOrDefaultAsync();
        if (user == null) return NotFound();

        user.FullName = model.FullName;
        user.Description = model.Description;
        user.Phone = model.Phone;
        user.DateOfBirth = model.DateOfBirth;
        user.Gender = model.Gender;
        user.Province = model.Address.Province;
        user.District = model.Address.District;
        user.Ward = model.Address.Ward;
        user.Address = model.Address.Address;

        await _context.SaveChangesAsync();
        return Ok();
    }

    [HttpPost("change-avatar")]
    public async Task<IActionResult> ChangeUserAvatar([FromForm] IFormFile avatar)
    {
        var userId = _userService.GetUserId(User);
        if (userId == -1) return Unauthorized("User not found");

        var user = await _context.Users.FindAsync(userId);
        if (user == null) return NotFound("User not found");

        // update avatar mới
        var fileName = CommonUtils.UploadImage(CommonUtils.USER_AVATAR, new IFormFile[] { avatar });

        // delete avatar cũ
        if (!string.IsNullOrEmpty(user.Avatar))
        {
            CommonUtils.DeleteImage(CommonUtils.USER_AVATAR, user.Avatar);
        }

        // Save database
        user.Avatar = fileName[0];
        await _context.SaveChangesAsync();

        return new JsonResult(new
        {
            avatar = AppPath.GenerateImagePath(AppPath.USER_AVATAR, user.Avatar)
        });
    }

    [HttpPost("change-password")]
    public async Task<IActionResult> ChangeUserPassword(ChangeUserPasswordModel model)
    {
        var userId = _userService.GetUserId(User);
        if (userId == -1) return Unauthorized("User not found");

        var user = await _context.Users.FindAsync(userId);
        if (user == null) return NotFound("User not found");

        if (!PasswordHasher.Verify(model.CurrentPassword, user.Password))
            return BadRequest("Mật khẩu cũ không đúng, vui lòng kiểm tra lại.");

        user.Password = PasswordHasher.Hash(model.NewPassword);
        await _context.SaveChangesAsync();

        return Ok("Thay đổi mật khẩu thành công");
    }
}
