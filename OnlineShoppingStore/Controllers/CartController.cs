using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using OnlineShoppingStore.Models;
using OnlineShoppingStore.ViewModel.LayoutViewModel;

namespace OnlineShoppingStore.Controllers;
public class CartController(ICartItemRepository _CartItemRepository,
                            ICartRepository cartRepository,
                            IProductRepository productRepository,
                            IMapper mapper,
                            UserManager<ApplicationUser> userManager
    ) : Controller
{
    private readonly ICartItemRepository CartItemRepository = _CartItemRepository;
    private readonly ICartRepository _CartRepository = cartRepository;
    private readonly IProductRepository _ProductRepository = productRepository;
    private readonly UserManager<ApplicationUser> _UserManager = userManager;

    public IActionResult ShowCartItems(int cartId)
    {
        int cartid=(int) _UserManager.GetUserAsync(User).Result.cartid;
        var CartItemList = CartItemRepository.ShowCartItems(cartid);
        return View("ShowCartToEdit", CartItemList);
    }



    [HttpPost]
    public IActionResult AddToCart(int productId, int CartId, int Quantity,bool temp=false)
    {
        CartId = (int)_UserManager.GetUserAsync(User).Result.cartid;

        _CartRepository.AddToCart(productId, CartId, Quantity);
        _CartRepository.SaveChanges();
        if (temp) { return RedirectToAction("Details", "Product", new { ProductId = productId , temp=true}); }
        return NoContent();
    }

    public ActionResult DeleteItem(int CartItemId, int cartid)
    {
        _CartRepository.DeleteItem(CartItemId, cartid);
        return RedirectToAction("ShowCartItems");
    }

    public ActionResult UpdateCartItem(CartItem[] itemslist)
    {
        _CartRepository.UpdateCartItem(itemslist);
        return RedirectToAction("ShowCartItems");

    }

    public IActionResult EditQuantity(int Quantity, int ProductId)
    {
        _CartRepository.EditQuantity(Quantity, ProductId);
        return RedirectToAction("ShowCartItems");
    }




}

