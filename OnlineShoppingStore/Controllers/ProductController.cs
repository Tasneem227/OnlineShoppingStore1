using Microsoft.AspNetCore.Mvc;

namespace OnlineShoppingStore.Controllers;
public class ProductController(IProductRepository productRepository) : Controller
{
    private readonly IProductRepository ProductRepository = productRepository;

    public IActionResult ShowAll()
    {
        var ProductsList =ProductRepository.GetAll();
        return View("Catalog",ProductsList);
    }
}
