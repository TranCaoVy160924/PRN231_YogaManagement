using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using YogaManagement.Client.Helper;
using YogaManagement.Client.OdataClient.Default;
using YogaManagement.Client.OdataClient.YogaManagement.Contracts.MemberLevel;

namespace YogaManagement.Client.Controllers;

[Authorize(Roles = "Admin")]
public class MemberLevelDiscountController : Controller
{

    private readonly Container _context;
    private readonly INotyfService _notyf;
    private readonly JwtManager _jwtManager;

    public MemberLevelDiscountController(Container context,
        INotyfService notyf,
        JwtManager jwtManager)
    {
        _context = context;
        _notyf = notyf;
        _jwtManager = jwtManager;
        _context.BuildingRequest += (sender, e) => _jwtManager.OnBuildingRequest(sender, e);
    }

    //get
    public async Task<IActionResult> Index()
    {
        var memberLevel = await _context.MemberLevels.ExecuteAsync();
        return View(memberLevel);
    }

    //detail
    public async Task<IActionResult> Details(int? id)
    {
        try
        {
            if (id == null || _context.Courses == null)
            {
                throw new Exception("Not found");
            }

            var memberLevel = await _context.MemberLevels.ByKey(id.Value).GetValueAsync();
            return View(memberLevel);
        }
        catch(Exception ex)
        {
            throw new Exception(ex.Message, ex);
        }
    }

    //edit request
    public async Task<IActionResult> Edit(int? id)
    {
        try
        {
            if (id == null || _context.Users == null)
            {
                throw new Exception("Not Found");
            }

            var memberLevel = await _context.MemberLevels.ByKey(id.Value).GetValueAsync();
            return View(memberLevel);
        }
        catch (InvalidOperationException ex)
        {
            _notyf.Error(ex.ReadOdataErrorMessage());
            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            _notyf.Error(ex.Message);
            return RedirectToAction(nameof(Index));
        }
    }

    //edit response
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("Id, Silver, Gold, Platinum")] MemberLevelDiscountDTO memberLevel)
    {
        if (id != memberLevel.Id)
        {
            _notyf.Warning("Invalid update target");
            return RedirectToAction(nameof(Index));
        }

        try
        {
            if (!ModelState.IsValid)
            {
                throw new Exception("Invalid input");
            }

            var updateLevel = _context.MemberLevels.ByKey(id).GetValue();

            updateLevel.Id = 1;
            updateLevel.Silver = memberLevel.Silver;
            updateLevel.Gold = memberLevel.Gold;
            updateLevel.Platinum = memberLevel.Platinum;

            _context.UpdateObject(updateLevel);
            await _context.SaveChangesAsync();
            _notyf.Success("Member level updated");
            return RedirectToAction(nameof(Index));
        }
        catch (InvalidOperationException ex)
        {
            _notyf.Error(ex.ReadOdataErrorMessage());
            return View(memberLevel);
        }
        catch (Exception ex)
        {
            _notyf.Warning(ex.Message);
            return View(memberLevel);
        }
    }
}
