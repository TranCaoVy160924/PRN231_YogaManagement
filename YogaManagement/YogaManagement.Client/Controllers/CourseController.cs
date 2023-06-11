using Microsoft.AspNetCore.Mvc;

namespace YogaManagement.Client.Controllers;
public class CourseController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
