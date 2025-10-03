using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace OnlineShoppingStore.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderRepository _OrderRepository;
        private readonly UserManager<ApplicationUser> _UserManager;

        public OrderController(IOrderRepository orderRepository,UserManager<ApplicationUser> userManager)
        {
            _OrderRepository = orderRepository;
            _UserManager = userManager;
        }

        
        // cartitemid ,  cardid , productid , quantity  
        public async Task<IActionResult> CheckOut(List<CartItem> items)
        {
            var user = await _UserManager.GetUserAsync(User);
            ViewBag.Name = user?.FName+" "+user?.LName;
            ViewBag.Phone = user?.PhoneNumber;
            ViewBag.Email = user?.Email;
            ViewBag.Address = user?.Address;

            return View( items);
        }
        public IActionResult AddOrder(CartItem[] items)
        {
            var userId = _UserManager.GetUserId(User);
            _OrderRepository.AddOrder(items, userId);
            _OrderRepository.SaveChanges();
            return RedirectToAction("CustomerOrders");

        }
        public IActionResult CustomerOrders() { 
            var userId = _UserManager.GetUserId(User);
            var orders = _OrderRepository.GetOrdersByCustomerId(userId);
            return View(orders);
        }




    }
}
