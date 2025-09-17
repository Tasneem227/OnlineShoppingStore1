using Microsoft.AspNetCore.Mvc;

namespace OnlineShoppingStore.Controllers
{
    public class CategoryController : Controller
    {

        private readonly ICategoryRepository _CategoryRepository;

        public CategoryController(ICategoryRepository CategoryRepository)
        {
            _CategoryRepository = CategoryRepository;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult AllCategories()
        {
            var categories = _CategoryRepository.GetAllCategories();

            return View("Category", categories);
        }


    }
}
