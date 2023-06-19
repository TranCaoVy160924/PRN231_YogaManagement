using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using YogaManagement.Client.Helper;
using YogaManagement.Client.OdataClient.Default;
using YogaManagement.Client.OdataClient.YogaManagement.Contracts.Authority;
using YogaManagement.Client.RefitClient;
using YogaManagement.Contracts.Authority.Request;
using YogaManagement.Contracts.Authority.Response;

namespace EbookStore.Client.Controllers;
public class AuthController : Controller
{
    private readonly IAuthorityClient _userClient;
    private readonly Container _context;
    private readonly JwtManager _jwtManager;

    public AuthController(IAuthorityClient userClient,
        Container context,
        JwtManager jwtManager)
    {
        _userClient = userClient;
        _context = context;
        _jwtManager = jwtManager;
    }

    public IActionResult Login()
    {
        return View();
    }

    public IActionResult Register()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginRequest request)
    {
        if (!ModelState.IsValid)
        {
            return View(request);
        }

        try
        {
            LoginResponse response = await _userClient.AuthenticateAsync(request);
            _jwtManager.Login(response.Token);
            var principles = _jwtManager.TryGetPriciples();
            await HttpContext.SignInAsync(principles);

            if (_jwtManager.IsMember())
            {
                return RedirectToAction("Index", "Course");
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
        catch (Exception ex)
        {
            TempData["LoginErrorMessage"] = "Password or Email is invalid";
            return View(request);
        }
    }

    [HttpPost]
    public async Task<IActionResult> Register(UserDTO request)
    {
        if (!ModelState.IsValid)
        {
            return RedirectToAction("Register", "Auth");
        }

        try
        {
            //await _userClient.RegisterAsync(request);
            _context.AddToUsers(request);
            await _context.SaveChangesAsync();

            return RedirectToAction("Login", "Auth");
        }
        catch (Exception ex)
        {
            TempData["RegisterErrorMessage"] = ex.Message;
            return RedirectToAction("Register", "Auth");
        }
    }

    public async Task<IActionResult> Logout()
    {
        _jwtManager.Logout();
        await HttpContext.SignOutAsync();
        return RedirectToAction("Login", "Auth");
    }

    public IActionResult AccessDenied()
    {
        //return RedirectToAction("Login", "Auth");
        return View();
    }
}
