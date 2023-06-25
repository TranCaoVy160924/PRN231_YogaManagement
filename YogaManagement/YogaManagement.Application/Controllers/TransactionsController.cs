using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Deltas;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using YogaManagement.Application.Utilities;
using YogaManagement.Business.Repositories;
using YogaManagement.Contracts.Transaction;
using YogaManagement.Contracts.Wallet;
using YogaManagement.Domain.Enums;
using YogaManagement.Domain.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace YogaManagement.Application.Controllers;
public class TransactionsController : ODataController
{
    private readonly IMapper _mapper;
    private readonly WalletRepository _walletRepo;
    private readonly TransactionRepository _transacRepo;
    private readonly UserManager<AppUser> _userManager;

    public TransactionsController(WalletRepository walletRepo,
        IMapper mapper,
        TransactionRepository transacRepo,
        UserManager<AppUser> userManager)
    {
        _mapper = mapper;
        _walletRepo = walletRepo;
        _transacRepo = transacRepo;
        _userManager = userManager;
    }

    [EnableQuery]
    [Authorize]
    public ActionResult<IQueryable<TransactionDTO>> Get()
    {
        return Ok(_mapper.ProjectTo<TransactionDTO>(_transacRepo.GetAll()));
    }

    [EnableQuery]
    [Authorize]
    public async Task<ActionResult<TransactionDTO>> Get([FromRoute] int key)
    {
        var transaction = await _transacRepo.Get(key);

        if (transaction == null)
        {
            return NotFound();
        }

        return Ok(_mapper.Map<TransactionDTO>(transaction));
    }


    // For member transaction
    [Authorize(Roles = "Member")]
    public async Task<IActionResult> Post([FromBody] TransactionDTO transacRequest)
    {
        try
        {
            ModelState.ValidateRequest();
            var wallet = _walletRepo.GetAll()
                .SingleOrDefault(x => x.Id == transacRequest.Id && !x.IsAdminWallet)
                ?? throw new Exception("Wallet not exist");

            var user = _userManager.Users
                .SingleOrDefault(x => x.Id == wallet.AppUserId && x.Status == true)
                ?? throw new Exception("Wallet's owner not exist");

            var adminWallet = _walletRepo.GetAll()
                .SingleOrDefault(x => x.IsAdminWallet)
                ?? throw new Exception("Admin wallet not exist");
            var transaction = _mapper.Map<Transaction>(transacRequest);
            double transacAmount = transaction.Amount;

            switch (transaction.TransactionType)
            {
                case TransactionType.Payment:
                    {
                        if (wallet.Balance >= transacAmount)
                        {
                            wallet.Balance -= transacAmount;
                            adminWallet.Balance += transacAmount;

                            await _transacRepo.CreateAsync(transaction);
                            await _walletRepo.UpdateAsync(wallet);
                            await _walletRepo.UpdateAsync(adminWallet);
                        }
                        else
                        {
                            throw new Exception("Wallet balance not enough");
                        }
                        break;
                    }
                case TransactionType.Deposit:
                    {
                        wallet.Balance += transacAmount;
                        await _transacRepo.CreateAsync(transaction);
                        await _walletRepo.UpdateAsync(wallet);
                        break;
                    }
                case TransactionType.Refund:
                    {
                        if (adminWallet.Balance >= transacAmount)
                        {
                            wallet.Balance += transacAmount;
                            adminWallet.Balance -= transacAmount;
                            await _transacRepo.CreateAsync(transaction);
                            await _walletRepo.UpdateAsync(adminWallet);
                            await _walletRepo.UpdateAsync(wallet);
                            break;
                        }
                        else
                        {
                            throw new Exception("Refund not available now. Please try again later");
                        }
                    }
            }

            return Created(transacRequest);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
