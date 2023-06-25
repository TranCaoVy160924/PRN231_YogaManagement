using Microsoft.AspNetCore.Mvc;

namespace YogaManagement.Client.Controllers;
public class MemberLevelDiscountController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
