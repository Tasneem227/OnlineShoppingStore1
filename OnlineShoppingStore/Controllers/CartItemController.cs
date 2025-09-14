using Microsoft.AspNetCore.Mvc;

namespace OnlineShoppingStore.Controllers;
public class CartItemController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
