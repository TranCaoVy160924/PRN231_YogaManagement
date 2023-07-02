using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using NToastNotify.Helpers;
using System.Dynamic;
using YogaManagement.Application.Utilities;
using YogaManagement.Client.Helper;
using YogaManagement.Client.OdataClient.Default;
using YogaManagement.Client.OdataClient.YogaManagement.Contracts.Course;
using YogaManagement.Client.OdataClient.YogaManagement.Contracts.Transaction;
using YogaManagement.Client.OdataClient.YogaManagement.Contracts.Wallet;
using YogaManagement.Domain.Enums;
using YogaManagement.Domain.Models;

namespace YogaManagement.Client.Controllers;
public class WalletsController : Controller
{
    private readonly Container _context;
    private readonly INotyfService _notyf;
    private readonly JwtManager _jwtManager;

    public WalletsController(Container context,
        INotyfService notyf,
        JwtManager jwtManager)
    {
        _context = context;
        _notyf = notyf;
        _jwtManager = jwtManager;
        _context.BuildingRequest += (sender, e) => _jwtManager.OnBuildingRequest(sender, e);
    }

    public async Task<IActionResult> Index()
    {
        var userWallet = await _context.Wallets.ByKey(_jwtManager.GetUserId()).GetValueAsync();
        try
        {
            return View(userWallet);
        }
        catch (InvalidOperationException ex)
        {
            _notyf.Error(ex.ReadOdataErrorMessage());
            return View(userWallet);
        }
        catch (Exception ex)
        {
            _notyf.Error(ex.Message);
            return View(userWallet);
        }
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Index(double Money)
    {
        var userWallet = await _context.Wallets.ByKey(_jwtManager.GetProfileId()).GetValueAsync();
        try
        {
            ModelState.Remove("Id");
            ModelState.Remove("Content");
            ModelState.Remove("CreatedDate");
            ModelState.Remove("TransactionType");
            ModelState.Remove("WalletId");
            if (!ModelState.IsValid)
            {
                throw new Exception("Invalid input");
            }

            var AddingAmount = new TransactionDTO()
            {
                 Amount = Money,
                 Content = Money.ToString(),
                 CreatedDate = DateTime.Today,
                 TransactionType = TransactionType.Deposit.ToString(),
                 WalletId = _jwtManager.GetProfileId(),
            };

            _context.AddToTransactions(AddingAmount);

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
        catch (InvalidOperationException ex)
        {
            _notyf.Error(ex.ReadOdataErrorMessage());
            return View(userWallet); ;
        }
        catch (Exception ex)
        {
            _notyf.Error(ex.Message);
            return View(userWallet); ;
        }
    }
}
