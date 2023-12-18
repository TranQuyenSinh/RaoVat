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
using App.Utils;

namespace App.Controllers;

[ApiController]
[Route("api/manage-account")]
[Authorize(Roles = "Administrator")]
public class ManageAccountController : ControllerBase
{
    private readonly AppDbContext _context;

    public ManageAccountController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet("accounts")]
    public async Task<IActionResult> GetAllAccount()
    {
        var accounts = await _context.Users
        .Include(x => x.Role)
        .Select(x => new
        {
            Id = x.Id,
            FullName = x.FullName,
            Email = x.Email,
            Role = x.Role,
            Avatar = AppPath.GenerateImagePath(AppPath.USER_AVATAR, x.Avatar),
            Phone = x.Phone,
            Gender = x.Gender,
            Address = $"{x.Address}, {x.Ward}, {x.District}, {x.Province}",
            IsLocked = x.IsLocked,
            CreatedAt = x.CreatedAt
        })
        .ToListAsync();
        return new JsonResult(accounts);
    }

    [HttpGet("roles")]
    public async Task<IActionResult> GetAllRole()
    {
        var roles = await _context.Roles.ToListAsync();
        return new JsonResult(roles);
    }

    [HttpPost("edit-role")]
    public async Task<IActionResult> PhanQuyen([FromBody] EditRoleModel model)
    {
        var user = await _context.Users.FindAsync(model.UserId);
        if (user == null) return NotFound("User not found");

        user.RoleId = model.RoleId;
        await _context.SaveChangesAsync();
        return Ok("Phân quyền thành công");
    }

    [HttpGet("lock-account")]
    public async Task<IActionResult> KhoaTaiKhoan(int userId)
    {
        var user = await _context.Users.FindAsync(userId);
        if (user == null) return NotFound("User not found");

        user.IsLocked = !user.IsLocked;
        await _context.SaveChangesAsync();
        return Ok("Successfully");
    }

    [HttpGet]
    [Route("test")]
    public string Test()
    {
        return "test successfully";
    }
}
