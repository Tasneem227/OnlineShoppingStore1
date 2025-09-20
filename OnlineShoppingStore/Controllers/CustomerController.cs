using Microsoft.AspNetCore.Mvc;

namespace OnlineShoppingStore.Controllers;
public class CustomerController : Controller
{
    private readonly ICustomerRepository _CustomerRepository;

    public CustomerController(ICustomerRepository customerRepository)
    {
        _CustomerRepository = customerRepository;
    }
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult GetAllCustomers()
    {
       var list = _CustomerRepository.GetAllCustomers();
        return View("AllCustomers", list);
    }
}