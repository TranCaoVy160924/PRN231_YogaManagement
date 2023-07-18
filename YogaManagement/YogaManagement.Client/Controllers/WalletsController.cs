using AspNetCoreHero.ToastNotification.Abstractions;
using Azure.Core;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
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
using YogaManagement.Client.RefitClient;
using YogaManagement.Contracts.Authority.Request;
using YogaManagement.Contracts.Authority.Response;
using YogaManagement.Domain.Enums;
using YogaManagement.VNPayGateWay.Services;
using YogaManagement.VNPayGateWay.VnPayModels;

namespace YogaManagement.Client.Controllers;

[Authorize(Roles = "Member")]
public class WalletsController : Controller
{
    private readonly Container _context;
    private readonly INotyfService _notyf;
    private readonly JwtManager _jwtManager;
    private readonly IVnPayService _vnpay;
    private readonly IAuthorityClient _userClient;

    public WalletsController(Container context,
        INotyfService notyf,
        JwtManager jwtManager,
        IAuthorityClient userClient,
        IVnPayService vnpay)
    {
        _context = context;
        _notyf = notyf;
        _jwtManager = jwtManager;
        _userClient = userClient;
        _context.BuildingRequest += (sender, e) => _jwtManager.OnBuildingRequest(sender, e);
        _vnpay = vnpay;
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
        var userWallet = await _context.Wallets.ByKey(_jwtManager.GetUserId()).GetValueAsync();

        try
        {
            var url = _vnpay.CreatePaymentUrl(new PaymentInformationModel
            {
                Amount = Money,
                AppUserId = _jwtManager.GetUserId()
            }, Request.HttpContext);

            return Redirect(url);
        }
        catch (Exception ex)
        {
            _notyf.Error(ex.Message);
            return View(userWallet);
        }
    }

    public async Task<IActionResult> Payment()
    {
        var response = new PaymentResponseModel
        {
            PaymentMethod = Request.Query["vnp_BankCode"],
            OrderDescription = Request.Query["vnp_OrderInfo"],
            OrderId = Request.Query["vnp_TxnRef"],
            PaymentId = Request.Query["vnp_TransactionNo"],
            TransactionId = Request.Query["vnp_TransactionNo"],
            Token = Request.Query["vnp_SecureHash"],
            VnPayResponseCode = Request.Query["vnp_ResponseCode"],
            PayDate = Request.Query["vnp_PayDate"],
            Success = true // assume the request is successful
        };

        if (string.IsNullOrEmpty(response.PaymentMethod) ||
            string.IsNullOrEmpty(response.OrderDescription) ||
            string.IsNullOrEmpty(response.OrderId) ||
            string.IsNullOrEmpty(response.PaymentId) ||
            string.IsNullOrEmpty(response.TransactionId) ||
            string.IsNullOrEmpty(response.Token) ||
            string.IsNullOrEmpty(response.VnPayResponseCode) ||
            string.IsNullOrEmpty(response.PayDate))
        {
            _notyf.Error("Invalid payment data received");
            return RedirectToAction(nameof(Index));
        }

        if (response.VnPayResponseCode != "00")
        {
            _notyf.Information("Payment canceled");
            return RedirectToAction(nameof(Index));
        }

        var userWallet = await _context.Wallets.ByKey(_jwtManager.GetUserId()).GetValueAsync();

        string[] orderParts = response.OrderDescription.Split(' ');

        int appUserId = Convert.ToInt32(orderParts[0]);
        double amount = Convert.ToDouble(orderParts[1]);

        if (appUserId != _jwtManager.GetUserId())
        {
            _notyf.Error("User not match");
            return RedirectToAction(nameof(Index));
        }

        if (amount < 5000)
        {
            _notyf.Error("Must be more than 5000");
            return RedirectToAction(nameof(Index));
        }

        try
        {
            var AddingAmount = new TransactionDTO()
            {
                Amount = amount,
                Content = "Depoist " + amount.ToString(),
                CreatedDate = DateTime.Today,
                TransactionType = TransactionType.Deposit.ToString(),
                WalletId = userWallet.Id,
            };
            _context.AddToTransactions(AddingAmount);

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
        catch (InvalidOperationException ex)
        {
            _notyf.Error(ex.ReadOdataErrorMessage());
            return RedirectToAction("Index", new { userWallet });
        }
        catch (Exception ex)
        {
            _notyf.Error(ex.Message);
            return RedirectToAction("Index", new { userWallet });
        }
    }
}
