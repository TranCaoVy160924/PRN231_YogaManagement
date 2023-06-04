using YogaManagement.Domain.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Refit;
using System.Security.Claims;
using YogaManagement.Contracts.Authority.Request;
using YogaManagement.Client.RefitClient;
using YogaManagement.Client.Helper;

namespace EbookStore.Client.Controllers;
public class AuthController : Controller
{
    private readonly IAuthorityClient _userClient;

    public AuthController(IAuthorityClient userClient)
    {
        _userClient = userClient;
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
            return RedirectToAction("Login", "Auth");
        }

        try
        {
            string token = await _userClient.AuthenticateAsync(request);

            // Http login
            JwtManager jwtManager = new JwtManager(token);
            var claimsPrinciple = jwtManager.GetPriciples();
            await HttpContext.SignInAsync(claimsPrinciple);

            if (jwtManager.GetUserRole().Equals("User"))
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return RedirectToAction("Index", "Book");
            }
        }
        catch
        {
            TempData["LoginErrorMessage"] = "Password or Email is invalid";
            return RedirectToAction("Login", "Auth");
        }
    }

    [HttpPost]
    public async Task<IActionResult> Register(RegisterRequest request)
    {
        if (!ModelState.IsValid)
        {
            return RedirectToAction("Register", "Auth");
        }

        try
        {
            await _userClient.RegisterAsync(request);

            return RedirectToAction("Login", "Auth");
        }
        catch (Exception ex)
        {
            TempData["RegisterErrorMessage"] = "Register unccessfully";
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
