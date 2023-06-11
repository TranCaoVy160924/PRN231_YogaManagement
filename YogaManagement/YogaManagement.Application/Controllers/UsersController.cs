using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Formatter;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Attributes;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using YogaManagement.Application.Utilities;
using YogaManagement.Contracts.Authority.Request;
using YogaManagement.Contracts.Authority.Response;
using YogaManagement.Domain.Models;

namespace YogaManagement.Application.Controllers;
public class UsersController : ODataController
{
    private readonly UserManager<AppUser> _userManager;
    private readonly JwtHelper _jwtHelper;
    private readonly IMapper _mapper;

    public UsersController(UserManager<AppUser> userManager,
        IMapper mapper,
        JwtHelper jwtHelper)
    {
        _userManager = userManager;
        _mapper = mapper;
        _jwtHelper = jwtHelper;
    }

    [EnableQuery]
    public ActionResult<IQueryable<UserResponse>> Get()
    {
        return Ok(_mapper.ProjectTo<UserResponse>(_userManager.Users));
    }

    [EnableQuery]
    public async Task<ActionResult<UserResponse>> Get([FromRoute] int key)
    {
        var member = await _userManager.FindByIdAsync(key.ToString());

        if (member == null)
        {
            return NotFound();
        }

        return Ok(_mapper.Map<UserResponse>(member));
    }

    [HttpPost("odata/[controller]/auth")]
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
        return Ok(new LoginResponse { Token = _jwtHelper.CreateToken(user, request.Email, role), Role = role });
    }

    public async Task<IActionResult> Post(RegisterRequest registerRequest)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        if (registerRequest.Password != registerRequest.ConfirmPassword)
        {
            return BadRequest("Confirm password must match password");
        }

        var hasher = new PasswordHasher<AppUser>();
        string firstName = registerRequest.FirstName.Trim();
        string lastName = registerRequest.LastName.Trim();
        var user = new AppUser
        {
            Firstname = firstName,
            Lastname = lastName,
            PasswordHash = hasher.HashPassword(null, "12345678"),
            UserName = firstName + lastName,
            Email = registerRequest.Email,
            EmailConfirmed = true,
            SecurityStamp = string.Empty,
            Address = registerRequest.Address,
        };

        var result = await _userManager.CreateAsync(user, registerRequest.Password);
        var resultRole = await _userManager
            .AddToRoleAsync(user, role: "Member");

        if (result.Succeeded && resultRole.Succeeded)
        {
            return Ok();
        }

        return BadRequest("Create user unsuccessfully!");
    }

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
}
