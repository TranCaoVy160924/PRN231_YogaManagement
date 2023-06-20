using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Refit;
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
    private readonly INotyfService _notyf;

    public AuthController(IAuthorityClient userClient,
        Container context,
        JwtManager jwtManager,
        INotyfService notyf)
    {
        _userClient = userClient;
        _context = context;
        _jwtManager = jwtManager;
        _notyf = notyf;
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
        try
        {
            if (!ModelState.IsValid)
            {
                throw new Exception("Invalid input");
            }

            LoginResponse response = await _userClient.AuthenticateAsync(request);
            _jwtManager.Login(response.Token);
            var principles = _jwtManager.TryGetPriciples();
            await HttpContext.SignInAsync(principles);

            _notyf.Success("Hello " + _jwtManager.GetEmail());
            return RedirectToAction("Index", "Home");
        }
        catch (ApiException ex)
        {
            _notyf.Error(ex.ReadApiErrorMessage());
            return View(request);
        }
        catch (Exception ex)
        {
            _notyf.Warning(ex.Message);
            return View(request);
        }
    }

    [HttpPost]
    public async Task<IActionResult> Register(UserDTO request)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                throw new Exception("Invalid input");
            }

            _context.AddToUsers(request);
            await _context.SaveChangesAsync();

            return RedirectToAction("Login", "Auth");
        }
        catch (InvalidOperationException ex)
        {
            _notyf.Error(ex.ReadOdataErrorMessage());
            return View(request);
        }
        catch (Exception ex)
        {
            _notyf.Warning(ex.Message);
            return View(request);
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
        return View();
    }
}
