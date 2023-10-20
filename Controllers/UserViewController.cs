using Microsoft.AspNetCore.Mvc;
using App.Models;
using App.Data;
using Microsoft.EntityFrameworkCore;
using App.Services;

namespace App.Controllers;

[ApiController]
[Route("api/user-view")]
public class UserViewController : ControllerBase
{
    private readonly ILogger<Test> _logger;
    private readonly AppDbContext _context;
    private readonly UserService _userService;

    public UserViewController(ILogger<Test> logger, AppDbContext context, UserService userService)
    {
        _logger = logger;
        _context = context;
        _userService = userService;
    }

    [HttpGet("detail-shop")]
    public IActionResult GetDetailShop(int shopId, int? userId = null)
    {
        return new JsonResult(_userService.GetDetailShop(shopId, userId));
    }

}
