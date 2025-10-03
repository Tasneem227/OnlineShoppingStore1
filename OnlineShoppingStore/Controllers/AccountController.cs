using AutoMapper;
using HospitalMS.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineShoppingStore.Data;
using OnlineShoppingStore.ViewModel.AccountViewModel;

namespace OnlineShoppingStore.Controllers;
public class AccountController : Controller
{
    private readonly UserManager<ApplicationUser> UserManager;
    private readonly IMapper Mapper;
    private readonly SignInManager<ApplicationUser> signInManager;
    private readonly IMapper mapper;
    private readonly ICustomerRepository _CustomerRepository;
    private readonly ICartRepository _CartRepository;

    public AccountController(UserManager<ApplicationUser> userManager
        , IMapper mappingProfile, SignInManager<ApplicationUser> signInManager
      , ApplicationDbContext context, IMapper mapper,
        ICustomerRepository customerRepository,
        ICartRepository cartRepository
        )
    {
        this.UserManager = userManager;
        this.Mapper = mappingProfile;
        this.signInManager = signInManager;
        this.mapper = mapper;
        _CustomerRepository = customerRepository;
        _CartRepository = cartRepository;
    }
    public IActionResult Register()
    {
        RegisterViewModel registerViewModel = new RegisterViewModel();
        return View("Register", registerViewModel);
    }
    [HttpPost]
    public async Task<IActionResult> saveRegister(RegisterViewModel registerViewModel)
    {
        ModelState.Remove("Image");
        if (ModelState.IsValid)
        {
            //Mapping
            var Userapp = Mapper.Map<ApplicationUser>(registerViewModel);
            Userapp.cartid=_CartRepository.GetLastCartId()+1;
            var customer = mapper.Map<Customer>(registerViewModel);
            //Save to DB
            
            IdentityResult result = await UserManager.CreateAsync(Userapp, registerViewModel.Password);
            if (result.Succeeded)
            {
                //Assign to role 
                IdentityResult result1 = await UserManager.AddToRoleAsync(Userapp, "Customer");
                if (result1.Succeeded)
                {
                    //create cookie
                    await signInManager.SignInAsync(Userapp, false);


                    customer.UserId = Userapp.Id;
                    _CustomerRepository.Add(customer);
                    _CustomerRepository.SaveChanges();
                    _CartRepository.AddCart(customer.CustomerId);
                    _CartRepository.SaveChanges();
                    return RedirectToAction("Index", "Home");
                }
                foreach (var item in result1.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
            }
            foreach (var item in result.Errors)
            {
                ModelState.AddModelError("", item.Description);
            }

        }
        return View("Register", registerViewModel);
    }
    [Authorize]
    public async Task<IActionResult> SignOut()
    {
        await signInManager.SignOutAsync();
        return RedirectToAction("Index", "Home");
    }

    public IActionResult Login()
    {
        LoginUserViewModel loginViewModel = new LoginUserViewModel();
        return View("Login", loginViewModel);
    }
    [HttpPost]
    public async Task<IActionResult> Login(LoginUserViewModel loginUser)
    {
        if (ModelState.IsValid)
        {
            ApplicationUser appuser = await UserManager.FindByNameAsync(loginUser.UserName);
            if (appuser != null)
            {
                bool check = await UserManager.CheckPasswordAsync(appuser, loginUser.Password);
                if (check)
                {
                    await signInManager.SignInAsync(appuser, loginUser.RememberMe);
                    if (await UserManager.IsInRoleAsync(appuser, "Admin"))
                    {
                        return RedirectToAction("DashBoard", "Admin");
                    }
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", "Wrong Password ");
            }
            else
            {
                ModelState.AddModelError("", "User Name or Password May Be Wrong");
            }
        }
        return View("Login", loginUser);
    }
    [Authorize]
    public async Task<IActionResult> ProfileAsync()
    {

        var user = await UserManager.GetUserAsync(User);
        if (user == null)
        {
            return NotFound("User not found");
        }
        object value = System.Enum.TryParse<Gender>(user.Gender, out var parsedGender);

        var model = new ProfileViewModel
        {
            FirstName = user.FName,
            LastName = user.LName,
            UserName = user.UserName,
            Gender = parsedGender,
            DateOfBirth = user.BirthDate,
            PhoneNumber = user.PhoneNumber,
            Image = user.ProfilePicture
        };

        return View("Profile", model);
    }
    public async Task<ActionResult> CheckUserName(string UserName, int Id)
    {

        var found = await UserManager.FindByNameAsync(UserName);
        if (found != null)
        {


            return Json(false);
        }
        return Json(true);

    }
}
