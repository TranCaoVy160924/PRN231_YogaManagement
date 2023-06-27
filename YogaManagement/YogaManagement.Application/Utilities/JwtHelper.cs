using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using YogaManagement.Domain.Models;

namespace YogaManagement.Application.Utilities;

public class JwtHelper
{
    private readonly IConfiguration _config;

    public JwtHelper(IConfiguration config)
    {
        _config = config;
    }

    public string CreateToken(AppUser user, string email, string role)
    {
        var signingCredentials = GetSigningCredentials();
        var claims = GetClaims(user, email, role);
        var tokenOptions = GenerateTokenOptions(signingCredentials, claims);

        return new JwtSecurityTokenHandler().WriteToken(tokenOptions);
    }

    private IList<Claim> GetClaims(AppUser user, string email, string role)
    {
        return new List<Claim>
            {
                new Claim(ClaimTypes.Sid, user.Id.ToString()),
                new Claim(ClaimTypes.GivenName, $"{user.Firstname} {user.Lastname}"),
                new Claim(ClaimTypes.Email, email),
                new Claim(ClaimTypes.Role, role),
                role == "Member"? new Claim("Profile", user.Member.Id.ToString()) : null,
                role == "Teacher"? new Claim("Profile", user.TeacherProfile.Id.ToString()) : null
            };
    }

    private JwtSecurityToken GenerateTokenOptions(SigningCredentials signingCredentials, IList<Claim> claims)
    {
        return new JwtSecurityToken
            (issuer: _config["JwtSettings:validIssuer"],
            audience: _config["JwtSettings:validIssuer"],
            claims: claims,
            expires: DateTime.Now.AddHours(int.Parse(_config["JwtSettings:expires"])),
            signingCredentials: signingCredentials);
    }

    private SigningCredentials GetSigningCredentials()
    {
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JwtSettings:Key"]));
        return new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
    }
}
