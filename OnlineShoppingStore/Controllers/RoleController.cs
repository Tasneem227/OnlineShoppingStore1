using HospitalMS.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace OnlineShoppingStore.Controllers;
public class RoleController : Controller
{
    private readonly RoleManager<IdentityRole> roleManager;

    public RoleController(RoleManager<IdentityRole> roleManager)
    {
        this.roleManager = roleManager;
    }
    public IActionResult AddRole()
    {
        RoleViewModel roleModel = new RoleViewModel();
        return View("AddRole", roleModel);
    }
    public async Task<IActionResult> SaveRole(RoleViewModel roleModel)
    {
        if (ModelState.IsValid)
        {
            IdentityRole role = new IdentityRole();
            role.Name = roleModel.RoleName;
            IdentityResult result = await roleManager.CreateAsync(role);
            if (result.Succeeded)
            {
                ViewBag.sucess = "true";
                return View("AddRole");
            }
            foreach (var item in result.Errors)
            {
                ModelState.AddModelError("", item.Description);
            }
            return View("AddRole", roleModel);

        }
        return View("AddRole", roleModel);
    }
}

