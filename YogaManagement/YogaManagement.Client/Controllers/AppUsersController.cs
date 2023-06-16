using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using YogaManagement.Client.OdataClient.Default;
using YogaManagement.Client.OdataClient.YogaManagement.Contracts.Authority;

namespace YogaManagement.Client.Controllers
{
    public class AppUsersController : Controller
    {
        private readonly Container _context;

        public AppUsersController(Container context)
        {
            _context = context;
        }

        // GET: AppUsers
        public async Task<IActionResult> Index()
        {
            var appUserDbContext = await _context.Users
                .ExecuteAsync();
            return View(appUserDbContext);
        }

        // GET: AppUsers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Users == null)
            {
                return NotFound();
            }

            var appUser = _context.Users
                .Where(u => u.Id == id)
                .SingleOrDefault();
            if (appUser == null)
            {
                return NotFound();
            }

            return View(appUser);
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
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewData["Error"] = ex.Message;
                return View(appUser);
            }
        }

        // GET: AppUsers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Users == null)
            {
                return NotFound();
            }

            var appUser = await _context.Users.ByKey(id.Value).GetValueAsync();
            if (appUser == null)
            {
                return NotFound();
            }
            return View(appUser);
        }

        // POST: AppUsers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id, FirstName, LastName, Status, Address, Email, Password, ConfirmPassword, Role")] UserDTO appUser)
        {
            try
            {
                if (id != appUser.Id)
                {
                    return NotFound();
                }

                if (!ModelState.IsValid)
                {
                    throw new Exception("Invalid input");
                }

                var updateUser = _context.Users.ByKey(id).GetValue();

                updateUser.FirstName = appUser.FirstName;
                updateUser.LastName = appUser.LastName;
                updateUser.Address = appUser.Address;
                updateUser.Email = appUser.Email;
                updateUser.Password = appUser.Password;
                updateUser.ConfirmPassword = appUser.Password;
                updateUser.Role = updateUser.Role;
                updateUser.Status = updateUser.Status;

                _context.UpdateObject(updateUser);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewData["Error"] = ex.Message;
                return View(appUser);
            }
        }

        // GET: AppUsers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Users == null)
            {
                return NotFound();
            }

            var appUser = await _context.Users
                .ByKey(id.Value).GetValueAsync();
            if (appUser == null)
            {
                return NotFound();
            }

            return View(appUser);
        }

        // POST: AppUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var appUser = _context.Users.ByKey(id).GetValue();
            if (appUser != null)
            {
                _context.DeleteObject(appUser);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AppUserExists(int id)
        {
            return (_context.Users?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
