using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OnlineShoppingStore.ViewModel.AdminViewModel;

namespace OnlineShoppingStore.Controllers;
public class AdminController : Controller
{
    private readonly IProductRepository ProductRepository;
    private readonly ICategoryRepository CategoryRepository;
    private readonly IMapper Mapper;

    public AdminController(IProductRepository productRepository,
                            ICategoryRepository categoryRepository,
                            IMapper mapper
        )
    {
        ProductRepository = productRepository;
        CategoryRepository = categoryRepository;
        Mapper = mapper;
    }
    public IActionResult DashBoard()
    {
        return View();
    }
    public IActionResult AddProduct()
    {
        AddProductViewModel model = new AddProductViewModel();  
        model.Categories = CategoryRepository.GetAllCategories();
        return View(model);
    }
    [HttpPost]
    public IActionResult SaveNewProduct(AddProductViewModel viewModel)
    {
        if (ModelState.IsValid)
        {
            Product product=Mapper.Map<Product>(viewModel);
            ProductRepository.Add(product);
            ProductRepository.SaveChanges();
            return RedirectToAction("DashBoard");

        }
        else
        {
            ModelState.AddModelError("CategoryId", "Choose a Category ");
        }
        
            viewModel.Categories = CategoryRepository.GetAllCategories();
            return View("AddProduct", viewModel);
    }
    public IActionResult UpdateProduct(int productId)
    {
        return View();
    }
    public IActionResult SaveUpdatedProduct()
    {
        return View();
    }
    public IActionResult DeleteProduct(int productId)
    {
        return View();
    }
    public IActionResult ShowAllOrders()
    {
        return View();
    }
    public IActionResult ShowOrderDetails(int orderId)
    {
        return View();
    }
    public IActionResult UpdateOrderStatus(int orderId)
    {
        return View();
    }
    public IActionResult ShowAllUsers()
    {
        return View();
    }
    public IActionResult ShowAllProducts()
    {
        var products = ProductRepository.GetAll();
        products= ProductRepository.GetAll();
        return View(products);
    }

    // Custom Validators for Admin 
    public IActionResult RepeatedProductName(string Name) =>Json( !ProductRepository.ProductExists(Name));
        
    
}
