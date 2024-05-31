using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using NaLibApi.DTO;
using NaLibApi.Models;

namespace NaLibApi.Services;

public class AuthenticationService
{
    private readonly UserService _userService;
    private readonly IConfiguration _configuration;

    public AuthenticationService(UserService userService, IConfiguration configuration)
    {
        _userService = userService;
        _configuration = configuration;
    }

    public async Task<string> AunthenticateAsync(CredentialDto data)
    {
        var user = await _userService.AuthenticateAsync(data);
        if (user == null)
        {
            throw new Exception("Invalid credentials");
        }

        return GenerateWebTokenAsync(user);
    }

    private string GenerateWebTokenAsync(User user)
    {
        var hash = _configuration.GetSection("Jwt");
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(hash["Key"]));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.FullName),
            new Claim("userId", user.Id.ToString()),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

        var token = new JwtSecurityToken(
            issuer: hash["Issuer"],
            audience: hash["Audience"],
            claims: claims,
            expires: DateTime.Now.AddHours(hash["Duration"] != null ? Int32.Parse(hash["Duration"]) : 1 ),
            signingCredentials: credentials);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}