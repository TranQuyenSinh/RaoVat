using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace App.Services;

public class AuthServices
{
    private readonly IConfiguration _configuration;

    public AuthServices(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public JwtSecurityToken GetJwtToken(
        string email,
        TimeSpan expiration,
        Claim[] additionalClaims = null)
    {
        string signingKey = _configuration["JWT:Key"];
        string issuer = _configuration["JWT:Issuer"];
        string audience = _configuration["JWT:Audience"];

        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Email,email),
            // this guarantees the token is unique
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

        if (additionalClaims is object)
        {
            var claimList = new List<Claim>(claims);
            claimList.AddRange(additionalClaims);
            claims = claimList.ToArray();
        }

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(signingKey));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        return new JwtSecurityToken(
            issuer: issuer,
            audience: audience,
            expires: DateTime.UtcNow.Add(expiration),
            claims: claims,
            signingCredentials: creds
        );
    }
}