using Microsoft.AspNetCore.Mvc;

namespace OnlineShoppingStore.Controllers;
public class CartController(ICartItemRepository _CartItemRepository,
                            ICartRepository cartRepository,
                            IProductRepository productRepository) : Controller
{
    private readonly ICartItemRepository CartItemRepository = _CartItemRepository;
    private readonly ICartRepository _CartRepository = cartRepository;
    private readonly IProductRepository _ProductRepository = productRepository;
    public IActionResult ShowCartItems(int CartId)
    {
        CartId = 1;
        var CartItemList= CartItemRepository.ShowCartItems(CartId);
        return View("ShowCart", CartItemList);
    }
    public IActionResult AddToCart(int ItemId)
    {
        _CartRepository.AddToCart(ItemId);
        _CartRepository.SaveChanges();
        return NoContent() ;
    }
   
}

