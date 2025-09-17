using Microsoft.AspNetCore.Mvc;
using OnlineShoppingStore.ViewModel.ProductViewModel;
namespace OnlineShoppingStore.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository _ProductRepository;

        public ProductController(IProductRepository productRepository)
        {
            _ProductRepository = productRepository;
        }

        public IActionResult ShowAll()
        {
            var ProductsList = _ProductRepository.GetAll();
            return View("Catalog", ProductsList);
        }

        public IActionResult Details(int ProductId)
        {
            Product product = _ProductRepository.GetById(ProductId);
            ProductCartCartItemViewModelDiscount viewModel = new ProductCartCartItemViewModelDiscount();
            viewModel.ProductId = ProductId;

            viewModel.Name = product.Name;
            viewModel.Description = product.Description;
            viewModel.Price = product.Price;
            viewModel.ImageUrl = product.ImageUrl;
            viewModel.Brand = product.Brand;

            viewModel.StockQuantity = product.StockQuantity;


            return View("Item", viewModel);
        }
        public IActionResult ProductsByCategory(int CategoryId)
        {
            List<Product> list = _ProductRepository.GetProductByCategryId(CategoryId);
            return View("ProductCategory", list);
        }
    }

}



