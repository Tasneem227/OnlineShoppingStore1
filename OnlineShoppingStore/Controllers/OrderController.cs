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

        public IActionResult ShowAllOrders()
        {

            var OrderCustomer = _OrderRepository.GetAllOrders();

            return View("ShowOrders", OrderCustomer);
        }
        // cartitemid ,  cardid , productid , quantity  
        public IActionResult AddOrder(CartItem[] items)
        {
            var userId = _UserManager.GetUserId(User);
            _OrderRepository.AddOrder(items, userId);
            _OrderRepository.SaveChanges();
            return RedirectToAction("ShowCartItems", "Cart");

        }






    }
}
