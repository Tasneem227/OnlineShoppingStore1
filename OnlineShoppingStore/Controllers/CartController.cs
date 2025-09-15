using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OnlineShoppingStore.ViewModel.LayoutViewModel;

namespace OnlineShoppingStore.Controllers;
public class CartController(ICartItemRepository _CartItemRepository,
                            ICartRepository cartRepository,
                            IProductRepository productRepository,
                            IMapper mapper) : Controller
{
    private readonly ICartItemRepository CartItemRepository = _CartItemRepository;
    private readonly ICartRepository _CartRepository = cartRepository;
    private readonly IProductRepository _ProductRepository = productRepository;

    public IActionResult ShowCartItems(int CartId)
    {
        CartId = 1;
        var CartItemList = CartItemRepository.ShowCartItems(CartId);
        return View("ShowCart", CartItemList);
    }
    public IActionResult LayoutCartItems(int CartId)
    {
        CartId = 1;
        var CartItemList = CartItemRepository.ShowCartItems(CartId);
        List<LayoutViewModel> layoutViewModels = new List<LayoutViewModel>();
        foreach (var item in CartItemList)
        {
           layoutViewModels.Add(mapper.Map<LayoutViewModel>(item));
        }
        ViewBag.CartItemsCount = CartItemList.Count;
        ViewBag.totalPrice = CartItemList.Sum(x => x.Product.Price * x.Quantity);   
        return Json(layoutViewModels);
    }
    public IActionResult AddToCart(int productId, int CartId)
    {
        _CartRepository.AddToCart(productId, CartId);
        _CartRepository.SaveChanges();
        return NoContent();
    }
    public ActionResult DeleteItem(int CartItemId, int cartid)
    {
        _CartRepository.DeleteItem(CartItemId, cartid);
        return RedirectToAction("ShowCartItems");
    }

}

