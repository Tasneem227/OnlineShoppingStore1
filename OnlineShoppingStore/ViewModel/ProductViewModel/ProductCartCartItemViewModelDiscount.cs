using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineShoppingStore.ViewModel.ProductViewModel
{
    public class ProductCartCartItemViewModelDiscount
    {

        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
        public string Brand { get; set; }
        public string ImageUrl { get; set; }

        public int CategoryId { get; set; }

        public int CartId { get; set; }
        [ForeignKey("Customer")]
        public int CustomerId { get; set; }
        public int Id { get; set; }

        [Required(ErrorMessage = "Quantity is required")]
        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be a positive number greater than zero")]
        public int Quantity { get; set; }

        public int DiscountId { get; set; }


        public string Code { get; set; }
        public decimal Percentage { get; set; }
        public decimal Amount { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsActive { get; set; }
    }
}
