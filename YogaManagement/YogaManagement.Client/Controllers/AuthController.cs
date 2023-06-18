using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using YogaManagement.Client.Helper;
using YogaManagement.Client.OdataClient.Default;
using YogaManagement.Client.OdataClient.YogaManagement.Contracts.Authority;
using YogaManagement.Client.RefitClient;
using YogaManagement.Contracts.Authority.Request;

namespace EbookStore.Client.Controllers;
public class AuthController : Controller
{
    private readonly IAuthorityClient _userClient;
    private readonly Container _context;

    public AuthController(IAuthorityClient userClient, Container context)
    {
        _userClient = userClient;
        _context = context;
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
            string token = await _userClient.AuthenticateAsync(request);

            // Http login
            JwtManager jwtManager = new JwtManager();
            jwtManager.SetToken(token);
            //var claimsPrinciple = jwtManager.GetPriciples();
            //await HttpContext.SignInAsync(claimsPrinciple);

            if (!jwtManager.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return RedirectToAction("Index", "Course");
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

    [HttpPost]
    public async Task<IActionResult> Logout()
    {
        await HttpContext.SignOutAsync();
        return RedirectToAction("Index", "Home");
    }

    public IActionResult AccessDenied()
    {
        return RedirectToAction("Login", "Auth");
    }
}
