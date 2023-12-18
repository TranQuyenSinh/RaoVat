using System.Security.Claims;
using App.Data;
using App.RequestModels;
using App.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using App.Utils;
using App.Models;
namespace App.Controllers;

[ApiController]
[Route("api/auth")]
public class AuthController : ControllerBase
{
    private readonly ILogger<AuthController> _logger;
    private readonly AppDbContext _context;
    private readonly AuthService _authService;
    private readonly IConfiguration _configuration;

    public AuthController(ILogger<AuthController> logger, AppDbContext context, AuthService authService, IConfiguration configuration)
    {
        _logger = logger;
        _context = context;
        _authService = authService;
        _configuration = configuration;
    }

    [AllowAnonymous]
    [HttpPost("login")]
    public IActionResult LoginUser([FromBody] LoginModel loginUser)
    {
        var (success, statusCode, message, user) = _authService.LoginUser(loginUser.Email, loginUser.Password);
        if (!success)
        {
            return Unauthorized(message);
        }

        // Generate auth token
        var token = _authService.GenerateAccessToken(user);
        var refreshToken = _authService.GenerateRefreshToken(user);

        var cookieOptions = new CookieOptions()
        {
            Domain = "localhost:3000",
            Expires = DateTime.Now.AddDays(2),
            SameSite = SameSiteMode.Lax,
            Secure = true
        };

        Response.Cookies.Append("refreshToken", refreshToken, cookieOptions);
        return Ok(new
        {
            user.Id,
            user.FullName,
            user.Phone,
            avatar = AppPath.GenerateImagePath(AppPath.USER_AVATAR, user.Avatar),
            role = user.Role.RoleName,
            accessToken = token,
        });
    }


    [AllowAnonymous]
    [HttpPost("register-guest")]
    public IActionResult RegisterUser([FromBody] RegisterModel guest)
    {
        if (string.IsNullOrEmpty(guest.Email) || string.IsNullOrEmpty(guest.Password) || string.IsNullOrEmpty(guest.FullName))
        {
            return BadRequest("Vui lòng điền đẩy đủ các trường!");
        }
        var newGuest = new User()
        {
            Email = guest.Email,
            FullName = guest.FullName,
            Password = PasswordHasher.Hash(guest.Password),
        };

        var (Success, Message) = _authService.CreateNewGuest(newGuest);
        if (Success)
        {
            return Ok(Message);
        }
        else
        {
            return BadRequest(Message);
        }
    }

    [HttpPost]
    [Route("refresh-token")]
    public IActionResult RefreshToken([FromBody] RefreshTokenModel model)
    {
        string accessToken = model.AccessToken;
        string refreshToken = model.RefreshToken;
        if (string.IsNullOrEmpty(accessToken) || string.IsNullOrEmpty(refreshToken))
        {
            return BadRequest("Invalid client request");
        }

        var claims = _authService.GetClaimsFromToken(accessToken);
        if (claims.Claims.Count() == 0)
        {
            return BadRequest("Invalid access token or refresh token");
        }
        _ = int.TryParse(claims.FindFirst(ClaimTypes.Sid)?.Value, out int userId);

        var user = _context.Users.Include(x => x.Role).Where(x => x.Id == userId).FirstOrDefault();

        // nếu ko tìm thấy user, hoặc refresh token ko khớp trong DB, hoặc refresh token hết hạn
        if (user == null || user.RefreshToken != refreshToken || user.RefreshTokenExpiryTime <= DateTime.Now)
        {
            return BadRequest("Refresh token has expired, please login again!");
        }

        var newAccessToken = _authService.GenerateAccessToken(user);
        return Ok(new
        {
            accessToken = newAccessToken,
        });
    }

    [Authorize]
    [HttpGet("check-is-logged-in")]
    public IActionResult CheckUserIsLoggedIn()
    {
        return Ok();
    }

    [Authorize(Roles = "Administrator")]
    [HttpGet("check-role-admin")]
    public IActionResult CheckRoleAdmin()
    {
        return Ok();
    }

    [Authorize(Roles = nameof(RoleName.Administrator))]
    [HttpGet("users")]
    public IActionResult GetAllUsers()
    {
        return Ok(_context.Users.ToList());
    }


}