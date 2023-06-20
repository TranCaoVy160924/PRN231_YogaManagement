using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Mvc;
using YogaManagement.Client.Helper;
using YogaManagement.Client.OdataClient.Default;
using YogaManagement.Client.OdataClient.YogaManagement.Contracts.Authority;
using AuthorizeAttribute = Microsoft.AspNetCore.Authorization.AuthorizeAttribute;

namespace YogaManagement.Client.Controllers;

[Authorize(Roles = "Admin")]
public class AppUsersController : Controller
{
    private readonly Container _context;
    private readonly INotyfService _notyf;
    private readonly JwtManager _jwtManager;

    public AppUsersController(Container context,
        INotyfService notyf,
        JwtManager jwtManager)
    {
        _context = context;
        _notyf = notyf;
        _jwtManager = jwtManager;
        _context.BuildingRequest += (sender, e) => _jwtManager.OnBuildingRequest(sender, e);
    }

    // GET: AppUsers
    public async Task<IActionResult> Index()
    {
        var appUserDbContext = await _context.Users.ExecuteAsync();
        return View(appUserDbContext);
    }

    // GET: AppUsers/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        try
        {
            if (id == null || _context.Users == null)
            {
                throw new Exception("Not Found");
            }

            var appUser = await _context.Users.ByKey(id.Value).GetValueAsync();
            if (appUser == null)
            {
                throw new Exception("Not Found");
            }
            return View(appUser);
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

    // GET: AppUsers/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: AppUsers/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id, FirstName, LastName, Status, Address, Email, Password, ConfirmPassword, Role")] UserDTO appUser)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                throw new Exception("Invalid input");
            }

            var newUser = new UserDTO()
            {
                FirstName = appUser.FirstName,
                LastName = appUser.LastName,
                Address = appUser.Address,
                Email = appUser.Email,
                Password = appUser.Password,
                ConfirmPassword = appUser.Password,
                Role = appUser.Role,
                Status = true
            };

            _context.AddToUsers(appUser);

            await _context.SaveChangesAsync();
            _notyf.Success("New user created");
            return RedirectToAction(nameof(Index));
        }
        catch (InvalidOperationException ex)
        {
            _notyf.Error(ex.ReadOdataErrorMessage());
            return View(appUser);
        }
        catch (Exception ex)
        {
            _notyf.Warning(ex.Message);
            return View(appUser);
        }
    }

    // GET: AppUsers/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        try
        {
            if (id == null || _context.Users == null)
            {
                throw new Exception("Not Found");
            }

            var appUser = await _context.Users.ByKey(id.Value).GetValueAsync();
            if (appUser == null)
            {
                throw new Exception("Not Found");
            }
            return View(appUser);
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

    // POST: AppUsers/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("Id, FirstName, LastName, Status, Address, Email, Password, ConfirmPassword, Role")] UserDTO appUser)
    {
        if (id != appUser.Id)
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

            var updateUser = _context.Users.ByKey(id).GetValue();

            updateUser.FirstName = appUser.FirstName;
            updateUser.LastName = appUser.LastName;
            updateUser.Address = appUser.Address;
            updateUser.Email = appUser.Email;
            updateUser.Role = updateUser.Role;
            updateUser.Status = appUser.Status;

            _context.UpdateObject(updateUser);
            await _context.SaveChangesAsync();
            _notyf.Success("User updated");
            return RedirectToAction(nameof(Index));
        }
        catch (InvalidOperationException ex)
        {
            _notyf.Error(ex.ReadOdataErrorMessage());
            return View(appUser);
        }
        catch (Exception ex)
        {
            _notyf.Warning(ex.Message);
            return View(appUser);
        }
    }

    // GET: AppUsers/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        try
        {
            if (id == null || _context.Users == null)
            {
                throw new Exception("Not Found");
            }

            var appUser = await _context.Users.ByKey(id.Value).GetValueAsync();
            if (appUser == null)
            {
                throw new Exception("Not Found");
            }
            return View(appUser);
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

    // POST: AppUsers/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        try
        {
            var appUser = _context.Users.ByKey(id).GetValue();
            if (appUser != null)
            {
                _context.DeleteObject(appUser);
            }

            await _context.SaveChangesAsync();
            _notyf.Success("User deleted");
            return RedirectToAction(nameof(Index));
        }
        catch (InvalidOperationException ex)
        {
            _notyf.Error(ex.ReadOdataErrorMessage());
            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            _notyf.Warning(ex.Message);
            return RedirectToAction(nameof(Index));
        }
    }
}
