using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Deltas;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using YogaManagement.Application.Utilities;
using YogaManagement.Business.Repositories;
using YogaManagement.Contracts.Authority;
using YogaManagement.Contracts.Authority.Request;
using YogaManagement.Contracts.Authority.Response;
using YogaManagement.Domain.Models;

namespace YogaManagement.Application.Controllers;
public class UsersController : ODataController
{
    private readonly UserManager<AppUser> _userManager;
    private readonly MemberRepository _mRepo;
    private readonly TeacherProfileRepository _tRepo;
    private readonly WalletRepository _walletRepo;
    private readonly JwtHelper _jwtHelper;
    private readonly IMapper _mapper;

    public UsersController(UserManager<AppUser> userManager,
        MemberRepository mRepo,
        TeacherProfileRepository tRepo,
        WalletRepository walletRepo,
        IMapper mapper,
        JwtHelper jwtHelper)
    {
        _userManager = userManager;
        _mRepo = mRepo;
        _tRepo = tRepo;
        _walletRepo = walletRepo;
        _mapper = mapper;
        _jwtHelper = jwtHelper;
    }

    [EnableQuery]
    public ActionResult<IQueryable<UserDTO>> Get()
    {
        var users = _userManager.Users
            .Include(u => u.TeacherProfile)
            .Include(u => u.Member);
        var result = _mapper.ProjectTo<UserDTO>(users);
        return Ok(result);
    }

    [EnableQuery]
    public async Task<ActionResult<UserDTO>> Get([FromRoute] int key)
    {
        var member = await _userManager.Users
            .Include(u => u.TeacherProfile)
            .Include(u => u.Member)
            .FirstOrDefaultAsync(u => u.Id == key);

        if (member == null)
        {
            return NotFound("Not found");
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
        if (registerRequest.Role != "Member")
        {
            var claims = User.Claims;
            var role = claims.Where(c => c.Type == ClaimTypes.Role).SingleOrDefault();
            if (role == null || role.Value != "Admin")
            {
                return Unauthorized();
            }
        }

        try
        {
            ModelState.ValidateRequest();
            var hasher = new PasswordHasher<AppUser>();
            string firstName = registerRequest.FirstName.Trim();
            string lastName = registerRequest.LastName.Trim();
            var user = new AppUser
            {
                Firstname = firstName,
                Lastname = lastName,
                PasswordHash = hasher.HashPassword(null, registerRequest.Password),
                UserName = registerRequest.Email,
                Email = registerRequest.Email,
                EmailConfirmed = true,
                Status = true,
                SecurityStamp = string.Empty,
                Address = registerRequest.Address,
            };

            var result = await _userManager.CreateAsync(user, registerRequest.Password);
            var chosenRole = registerRequest.Role;
            var resultRole = await _userManager
                .AddToRoleAsync(user, role: chosenRole);

            if (result.Succeeded && resultRole.Succeeded)
            {
                if (chosenRole == "Member")
                {
                    var newMember = new Member()
                    {
                        AppUserId = user.Id
                    };
                    await _mRepo.CreateAsync(newMember);
                }
                else if (chosenRole == "Teacher")
                {
                    var newTeacher = new TeacherProfile()
                    {
                        AppUserId = user.Id
                    };
                    await _tRepo.CreateAsync(newTeacher);
                }

                await _walletRepo.CreateAsync(new Wallet
                {
                    AppUserId = user.Id,
                    Balance = 0,
                    Transactions = new List<Transaction>()
                });

                return Created(registerRequest);
            }

            throw new Exception("Create user unsuccessfully!");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [Authorize(Roles = "Admin")]
    public async Task<ActionResult> Delete([FromRoute] int key)
    {
        try
        {
            var user = await _userManager.FindByIdAsync(key.ToString());
            if (user != null)
            {
                var role = (await _userManager.GetRolesAsync(user)).SingleOrDefault();
                if (role == "Admin" || role == "Member")
                {
                    return Unauthorized();
                }

                user.Status = false;
                await _userManager.UpdateAsync(user);
            }

            return NoContent();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [Authorize(Roles = "Admin")]
    public async Task<ActionResult> Patch([FromRoute] int key, [FromBody] Delta<UserDTO> delta)
    {
        try
        {
            var updateRequest = delta.GetInstance();
            var user = await _userManager.FindByIdAsync(key.ToString());

            if (user == null)
            {
                return NotFound("Not found");
            }

            var role = (await _userManager.GetRolesAsync(user)).SingleOrDefault();
            if (role == "Admin" || role == "Member")
            {
                return Unauthorized();
            }

            var hasher = new PasswordHasher<AppUser>();
            string firstName = updateRequest.FirstName.Trim();
            string lastName = updateRequest.LastName.Trim();

            user.Firstname = firstName;
            user.Lastname = lastName;
            user.EmailConfirmed = true;
            user.SecurityStamp = string.Empty;
            user.Address = updateRequest.Address;
            user.Status = updateRequest.Status;

            await _userManager.UpdateAsync(user);

            return Updated(updateRequest);
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
