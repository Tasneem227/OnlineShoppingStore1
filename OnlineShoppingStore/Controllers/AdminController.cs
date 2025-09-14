using Microsoft.AspNetCore.Mvc;

namespace OnlineShoppingStore.Controllers;
public class AdminController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
