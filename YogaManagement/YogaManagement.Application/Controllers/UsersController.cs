using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Formatter;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Attributes;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using YogaManagement.Application.Utilities;
using YogaManagement.Contracts.Authority;
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
    public ActionResult<IQueryable<UserDTO>> Get()
    {
        var result = _mapper.ProjectTo<UserDTO>(_userManager.Users);
        return Ok(result);
    }

    [EnableQuery]
    public async Task<ActionResult<UserDTO>> Get([FromRoute] int key)
    {
        var member = await _userManager.FindByIdAsync(key.ToString());

        if (member == null)
        {
            return NotFound();
        }

        return Ok(_mapper.Map<UserDTO>(member));
    }

    [HttpPost("odata/[controller]/auth")]
    public async Task<IActionResult> Authenticate([FromBody] LoginRequest request)
    {
        try
        {
            ModelState.ValidateRequest();
            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user == null)
            {
                throw new Exception("Username or password is incorrect. Please try again");
            }

            var result = await _userManager.CheckPasswordAsync(user, request.Password);
            if (!result)
            {
                throw new Exception("Username or password is incorrect. Please try again");
            }

            var role = (await _userManager.GetRolesAsync(user)).FirstOrDefault();
            //var role = await _dbContext.AppRoles.FindAsync(user.RoleId);
            StaticValues.Usernames.Add(request.Email);
            return Ok(new LoginResponse { Token = _jwtHelper.CreateToken(user, request.Email, role), Role = role });
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    public async Task<IActionResult> Post([FromBody] UserDTO registerRequest)
    {
        try
        {
            ModelState.ValidateRequest();
            if (registerRequest.Password != registerRequest.ConfirmPassword)
            {
                throw new Exception("Confirm password must match password");
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

            var chosenRole = registerRequest.Role;

            var result = await _userManager.CreateAsync(user, registerRequest.Password);
            var resultRole = await _userManager
                .AddToRoleAsync(user, role: chosenRole);

            if (result.Succeeded && resultRole.Succeeded)
            {
                return Created(registerRequest);
            }

            throw new Exception("Create user unsuccessfully!");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
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
