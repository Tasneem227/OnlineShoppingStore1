using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace OnlineShoppingStore.ViewModel.AdminViewModel;

public class AddProductViewModel
{
    [Required(ErrorMessage = "Product name is required.")]
    [StringLength(100,MinimumLength =3 ,ErrorMessage = "Name cannot be between 3 and 100 characters.")]
    [Remote(action: "RepeatedProductName", controller:"Admin" , ErrorMessage ="The Product Name Used Before")]
    public string? Name { get; set; }
    [Required(ErrorMessage = "Description is required.")]
    [StringLength(500, ErrorMessage = "Description cannot be longer than 500 characters.")]
    public string? Description { get; set; }
    [Required(ErrorMessage = "Price is required.")]
    [Range(0.01,100000000000000000, ErrorMessage = "Price must be at least 0.01")]
    public decimal? Price { get; set; }
    [DisplayName("Stock Quantity")]
    [Required(ErrorMessage = "Stock quantity is required.")]
    [Range(0, int.MaxValue, ErrorMessage = "Stock must be a valid number.")]
    public int? StockQuantity { get; set; }
    [Required(ErrorMessage = "Product Brand is required.")]
    [StringLength(50, MinimumLength = 3, ErrorMessage = "Brand cannot be between 3 and 50 characters.")]
    public string? Brand { get; set; }
    [DisplayName("Image URL")]
    [Required(ErrorMessage = "Image URL is required.")]
    [FileExtensions(Extensions = "jpg,jpeg,png", ErrorMessage = "Image must be a JPG or PNG file.")]
    public string? ImageUrl { get; set; }

    public virtual ICollection<Category>? Categories { get; set; } = new List<Category>();
    [Required(ErrorMessage = "Category is required.")]
    public int? CategoryId { get; set; }
}
