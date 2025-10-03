using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OnlineShoppingStore.ViewModel.AdminViewModel;

namespace OnlineShoppingStore.Controllers;
public class AdminController : Controller
{
    private readonly IProductRepository ProductRepository;
    private readonly ICategoryRepository CategoryRepository;
    private readonly IOrderRepository _OrderRepository;
    private readonly ICustomerRepository _CustomerRepository;
    private readonly IMapper Mapper;

    public AdminController(IProductRepository productRepository,
                            ICategoryRepository categoryRepository,
                            IOrderRepository orderRepository,
                            ICustomerRepository CustomerRepository,
                            IMapper mapper
        )
    {
        ProductRepository = productRepository;
        CategoryRepository = categoryRepository;
        _OrderRepository = orderRepository;
        _CustomerRepository = CustomerRepository;
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
            Product product = Mapper.Map<Product>(viewModel);
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

    /// //////////// Edit Product ///////////// ///////////////////////////////////////////
    public IActionResult EditProduct(int productId, bool temp)
    {
        var Product = ProductRepository.GetById(productId);
        var model = Mapper.Map<EditProductViewModel>(Product);
        model.Categories = CategoryRepository.GetAllCategories();
        model.temp = temp;
        return View(model);

    }
    [HttpPost]
    public IActionResult SaveUpdatedProduct(EditProductViewModel viewModel)
    {
        if (ModelState.IsValid)
        {
            var product = Mapper.Map<Product>(viewModel);
            ProductRepository.Update(product);
            ProductRepository.SaveChanges();
            if ((bool)viewModel.temp)
            {
                return RedirectToAction("SearchForProduct");
            }
            else
            {
                return RedirectToAction("ShowAllProducts");
            }
        }
        else
        {
            ModelState.AddModelError("CategoryId", "Choose a Category ");
        }
        return View("EditProduct", viewModel);
    }

    public IActionResult DeleteProduct(int productId, bool? temp = false)
    {
        var product = ProductRepository.GetById(productId);
        if (product != null)
        {
            ProductRepository.Delete(product);
            ProductRepository.SaveChanges();
            if (!(bool)temp)
            {
                return RedirectToAction("ShowAllProducts");
            }
            else
            {
                return RedirectToAction("SearchForProduct");
            }
        }
        return View("ShowAllProducts");
    }
    public IActionResult SearchForProduct(string? productId, string? name)
    {
        List<Product> products = new List<Product>();

        if (!string.IsNullOrEmpty(productId))
        {
            if (int.TryParse(productId, out int id))
            {
                var product = ProductRepository.GetById(id);
                if (product != null) products.Add(product);
            }
        }
        else if (!string.IsNullOrEmpty(name))
        {
            products = ProductRepository.GetByName(name);
        }

        return View(products);
    }

    public IActionResult ShowAllOrders()
    {
        var OrderCustomer = _OrderRepository.GetAllOrders();
        return View("ShowOrders", OrderCustomer);
    }
    public  IActionResult UpdateStatus(Order order)
    {
        _OrderRepository.UpdateStatus(order);
        _OrderRepository.SaveChanges();
        return RedirectToAction("ShowAllOrders");
    }

    public IActionResult SearchForOrder(int? OrderId)
    {
        if (OrderId == null)
        {
            return View("ShowOrders", new List<Order>());
        }
        var order = _OrderRepository.SearchForOrder((int)OrderId);
        if (order != null)
        {
            return View("ShowOrders", order);
        }
        return View("ShowOrders", new List<Order>());
    }
    public IActionResult GetAllCustomers()
    {
        var list = _CustomerRepository.GetAllCustomers();
        return View("AllCustomers", list);
    }
    public IActionResult ShowAllProducts()
    {
        var products = ProductRepository.GetAll();
        products = ProductRepository.GetAll();
        return View(products);
    }

    // Custom Validators for Admin 
    public IActionResult RepeatedProductName(string Name) => Json(!ProductRepository.ProductExists(Name));


}
