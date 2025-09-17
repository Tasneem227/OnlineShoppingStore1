namespace OnlineShoppingStore.Controllers
{
    public class DiscountController
    {
        private readonly IDiscountRepository _IDiscountRepository;

        public DiscountController(IDiscountRepository IDiscountRepository)
        {
            _IDiscountRepository = IDiscountRepository;
        }

        //public IActionResult ApplyDiscount(int Code)
        //{
        //    _IDiscountRepository.ApplyDiscount(int code);
        //    return View("");
        //}

    }
}
