using System.Security.Claims;
using App.Data;
using App.RequestModels;
using App.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using App.Utils;
namespace App.Controllers;

[ApiController]
[Route("api/auth")]
public class AuthController : ControllerBase
{
    private readonly ILogger<AuthController> _logger;
    private readonly AppDbContext _context;
    private readonly AuthServices _authService;
    private readonly IConfiguration _configuration;

    public AuthController(ILogger<AuthController> logger, AppDbContext context, AuthServices authService, IConfiguration configuration)
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
        var user = _authService.LoginUser(loginUser.Email, loginUser.Password);
        if (user == null)
            return Unauthorized("Sai email hoặc mật khẩu, vui lòng nhập lại!");

        var claims = new List<Claim>();

        claims.Add(new Claim(ClaimTypes.Sid, user.Id.ToString()));
        claims.Add(new Claim("fullname", user.FullName));
        claims.Add(new Claim(ClaimTypes.Role, user.Role.RoleName));

        // Generate auth token
        _ = int.TryParse(_configuration["JWT:TokenValidityInHours"], out int accessTokenValidityInHours);
        _ = int.TryParse(_configuration["JWT:RefreshTokenValidityInDays"], out int refreshTokenValidityInDays);
        var token = _authService.GenerateAccessToken(user.Id, TimeSpan.FromHours(accessTokenValidityInHours), claims.ToArray());
        var refreshToken = _authService.GenerateRefreshToken();

        user.RefreshToken = refreshToken;
        user.RefreshTokenExpiryTime = DateTime.Now.AddDays(refreshTokenValidityInDays);
        _context.SaveChanges();

        var cookieOptions = new CookieOptions()
        {
            Expires = DateTime.Now.AddDays(2),
            Path = "/",
            HttpOnly = true,
            SameSite = SameSiteMode.Strict,
            Secure = true,
        };

        Response.Cookies.Append("refreshToken", refreshToken, cookieOptions);
        return Ok(new
        {
            user.Id,
            user.FullName,
            user.Phone,
            avatar = AppPath.GenerateUserAvatarUrl(user.Avatar),
            role = user.Role.RoleName,
            accessToken = token,
        });
    }

    [HttpPost]
    [Route("refresh-token")]
    public IActionResult RefreshToken(string? accessToken)
    {
        string? refreshToken = Request.Cookies["refreshToken"];

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

        _ = int.TryParse(_configuration["JWT:TokenValidityInHours"], out int accessTokenValidityInHours);
        var newAccessToken = _authService.GenerateAccessToken(userId, TimeSpan.FromHours(accessTokenValidityInHours), claims.Claims.ToArray());

        return Ok(new
        {
            accessToken = newAccessToken,
        });
    }

    [Authorize(Roles = nameof(RoleName.Administrator))]
    [HttpGet("users")]
    public IActionResult GetAllUsers()
    {
        return Ok(_context.Users.ToList());
    }


}