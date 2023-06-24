using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using YogaManagement.Business.Repositories;
using YogaManagement.Contracts.Transaction;
using YogaManagement.Contracts.Wallet;

namespace YogaManagement.Application.Controllers;
public class TransactionsController : ODataController
{
    private readonly IMapper _mapper;
    private readonly WalletRepository _walletRepo;
    private readonly TransactionRepository _transacRepo;

    public TransactionsController(WalletRepository walletRepo,
        IMapper mapper,
        TransactionRepository transacRepo)
    {
        _mapper = mapper;
        _walletRepo = walletRepo;
        _transacRepo = transacRepo;
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
        //var ygclassout = _mapper.Map<YogaClassDTO>(ygClass);

        return Ok(_mapper.Map<TransactionDTO>(transaction));
    }
}
