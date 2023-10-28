using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using App.Data;
using App.Models;
using App.Utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace App.Services;

public class AuthService
{
    private readonly AppDbContext _context;
    private readonly IConfiguration _configuration;

    public AuthService(IConfiguration configuration, AppDbContext context)
    {
        _configuration = configuration;
        _context = context;
    }

    public (bool, string, User?) LoginUser(string email, string password)
    {
        var user = _context.Users
                    .Include(u => u.Role)
                    .Where(x => x.Email == email).FirstOrDefault();
        if (user == null)
            return (
                Success: false,
                Message: "Email không hợp lệ",
                data: null
            );


        if (!PasswordHasher.Verify(password, user.Password))
            return (
                Success: false,
                Message: "Sai mật khẩu, vui lòng nhập lại!",
                data: null
            );

        return (
            Success: true,
            Message: "Đăng nhập thành công",
            data: user
        );
    }

    public (bool, string) CreateNewGuest(User user)
    {
        var u = _context.Users.Where(x => x.Email == user.Email).FirstOrDefault();
        if (u != null)
            return
            (
                Success: false,
                Message: "Email này đã được sử dụng, vui lòng chọn email khác"
            );

        user.Role = _context.Roles.FirstOrDefault(x => x.RoleName == RoleName.Guest);
        _context.Users.Add(user);
        _context.SaveChanges();

        return
        (
            Success: true,
            Message: "Đăng ký thành công"
        );
    }

    public string GenerateAccessToken(User user)
    {
        string signingKey = _configuration["JWT:Key"];
        string issuer = _configuration["JWT:Issuer"];
        string audience = _configuration["JWT:Audience"];
        _ = int.TryParse(_configuration["JWT:TokenValidityInHours"], out int accessTokenValidityInHours);

        // Add payload
        var claims = new List<Claim>() {
            new (ClaimTypes.Sid, user.Id.ToString()),
            new ("fullname", user.FullName),
            new (ClaimTypes.Role, user.Role.RoleName),
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(signingKey));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        var token = new JwtSecurityToken(
            issuer: issuer,
            audience: audience,
            // expires: DateTime.UtcNow.Add(TimeSpan.FromHours(accessTokenValidityInHours)),
            expires: DateTime.UtcNow.Add(TimeSpan.FromSeconds(10)),
            claims: claims,
            signingCredentials: creds
        );
        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    public string GenerateRefreshToken(User user)
    {
        _ = int.TryParse(_configuration["JWT:RefreshTokenValidityInDays"], out int refreshTokenValidityInDays);
        var randomNumber = new byte[64];
        using var rng = RandomNumberGenerator.Create();
        rng.GetBytes(randomNumber);
        var refreshToken = Convert.ToBase64String(randomNumber);

        user.RefreshToken = refreshToken;
        // user.RefreshTokenExpiryTime = DateTime.Now.AddDays(refreshTokenValidityInDays);
        user.RefreshTokenExpiryTime = DateTime.Now.AddSeconds(30);
        _context.SaveChanges();

        return refreshToken;
    }

    public ClaimsPrincipal? GetClaimsFromToken(string? token)
    {
        var tokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = false,
            ValidateIssuerSigningKey = true,
            ValidIssuer = _configuration["JWT:Issuer"],
            ValidAudience = _configuration["JWT:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Key"]))
        };

        var tokenHandler = new JwtSecurityTokenHandler();

        ClaimsPrincipal? claims = tokenHandler.ValidateToken(token, tokenValidationParameters, out SecurityToken securityToken);
        if (securityToken is not JwtSecurityToken jwtSecurityToken || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
            throw new SecurityTokenException("Invalid token");

        return claims;

    }
}