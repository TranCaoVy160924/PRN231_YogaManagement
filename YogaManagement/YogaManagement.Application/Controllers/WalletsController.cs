using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using YogaManagement.Business.Repositories;
using YogaManagement.Contracts.Wallet;

namespace YogaManagement.Application.Controllers;
public class WalletsController : ODataController
{
    private readonly IMapper _mapper;
    private readonly WalletRepository _walletRepo;
    private readonly TransactionRepository _transacRepo;

    public WalletsController(WalletRepository walletRepo,
        IMapper mapper,
        TransactionRepository transacRepo)
    {
        _mapper = mapper;
        _walletRepo = walletRepo;
        _transacRepo = transacRepo;
    }

    [EnableQuery]
    [Authorize]
    public ActionResult<IQueryable<WalletDTO>> Get()
    {
        return Ok(_mapper.ProjectTo<WalletDTO>(_walletRepo.GetAll()));
    }

    [EnableQuery]
    [Authorize]
    public async Task<ActionResult<WalletDTO>> Get([FromRoute] int key)
    {
        var wallet = await _walletRepo.Get(key);

        if (wallet == null)
        {
            return NotFound();
        }
        //var ygclassout = _mapper.Map<YogaClassDTO>(ygClass);

        return Ok(_mapper.Map<WalletDTO>(wallet));
    }
}
