using Microsoft.AspNetCore.Mvc;

namespace YogaManagement.Client.Controllers;
public class WalletController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
