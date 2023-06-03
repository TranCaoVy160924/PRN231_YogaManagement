using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.IdentityModel.Tokens;
using YogaManagement.Contracts.Authority.Request;
using YogaManagement.Contracts.Authority.Response;
using YogaManagement.Domain.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using YogaManagement.Contracts.User.Request;
using YogaManagement.Application;

namespace SteelanceX.Application.Controllers;
[Route("api")]
[ApiController]
public class AuthorityController : ControllerBase
{
    private readonly UserManager<AppUser> _userManager;
    private readonly IConfiguration _config;

    public AuthorityController(UserManager<AppUser> userManager, IConfiguration config)
    {
        _userManager = userManager;
        _config = config;
    }

    [HttpPost("auth/token/")]
    public async Task<IActionResult> Authenticate([FromBody] LoginRequest request)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var user = await _userManager.FindByEmailAsync(request.Email);
        if (user == null)
        {
            return BadRequest("Username or password is incorrect. Please try again");
        }

        var result = await _userManager.CheckPasswordAsync(user, request.Password);
        if (!result)
        {
            return BadRequest("Username or password is incorrect. Please try again");
        }

        var role = (await _userManager.GetRolesAsync(user)).FirstOrDefault();
        //var role = await _dbContext.AppRoles.FindAsync(user.RoleId);
        StaticValues.Usernames.Add(request.Email);
        return Ok(new LoginResponse { Token = CreateToken(user, request.Email, role), Role = role });
    }

    [HttpPost("auth")]
    public async Task<IActionResult> CreateUser(RegisterRequest registerRequest)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        if (registerRequest.Password != registerRequest.ConfirmPassword)
        {
            return BadRequest("Confirm password must match password");
        }

        //auto generate username
        string[] splitFirstName = registerRequest.FirstName.Trim().Split(' ');
        string fullFirstName = "";
        foreach (string slice in splitFirstName)
        {
            if (slice.Length > 0)
            {
                fullFirstName += slice.ToString().ToLower();
            }
        }
        string[] splitlastname = registerRequest.LastName.Trim().Split(' ');
        string fullLastName = "";
        foreach (string slice in splitlastname)
        {
            if (slice.Length > 0)
            {
                fullLastName += slice[0].ToString().ToLower();
            }
        }

        string username = fullFirstName + fullLastName;

        var hasher = new PasswordHasher<AppUser>();
        var user = new AppUser
        {
            Firstname = fullFirstName.Trim(),
            Lastname = fullLastName.Trim(),
            PasswordHash = hasher.HashPassword(null, "12345678"),
            UserName = username,
            Email = registerRequest.Email,
            EmailConfirmed = true,
            SecurityStamp = string.Empty,
            Address = "Hochiminh"
        };

        var result = await _userManager.CreateAsync(user, registerRequest.Password);
        var resultRole = await _userManager
            .AddToRoleAsync(user, registerRequest.IsFreelancer? "Freelancer" : "Business");

        if (result.Succeeded && resultRole.Succeeded)
        {
            return Ok();
        }

        return BadRequest("Create user unsuccessfully!");
    }

    //[HttpGet("auth/user-profile/")]
    //[Authorize]
    //public async Task<IActionResult> GetUserProfile()
    //{
    //    var result = await _userManager.FindByNameAsync(User.Identity.Name);
    //    var data = _mapper.Map<UserResponse>(result);

    //    return Ok(data);
    //}

    //[HttpPost("auth/change-password/")]
    //[Authorize]
    //public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordRequest request)
    //{
    //    if (!ModelState.IsValid)
    //    {
    //        return BadRequest(ModelState);
    //    }

    //    var user = await _userManager.FindByNameAsync(User.Identity.Name);

    //    var result = await _userManager.ChangePasswordAsync(user, request.CurrentPassword, request.NewPassword);

    //    if (!result.Succeeded)
    //    {
    //        return BadRequest(result.Errors);
    //    }

    //    user.IsLoginFirstTime = false;

    //    await _userManager.UpdateAsync(user);

    //    return Ok(new SuccessResponseResult<string>("Change password success!"));
    //}

    private string CreateToken(AppUser user, string username, string role)
    {
        var signingCredentials = GetSigningCredentials();
        var claims = GetClaims(user, username, role);
        var tokenOptions = GenerateTokenOptions(signingCredentials, claims);

        return new JwtSecurityTokenHandler().WriteToken(tokenOptions);
    }

    private IList<Claim> GetClaims(AppUser user, string username, string role)
    {
        return new List<Claim>
            {
                new Claim(ClaimTypes.GivenName, $"{user.Firstname} {user.Lastname}"),
                new Claim(ClaimTypes.Name, username),
                new Claim(ClaimTypes.Role, role),
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
