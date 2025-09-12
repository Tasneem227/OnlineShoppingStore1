using OnlineShoppingStore.Enum;

namespace OnlineShoppingStore.Models;

public class Admin
{
    public int AdminId { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public DateOnly DateOfBirth { get; set; }
    public Gender Gender { get; set; }
    public string PhoneNumber { get; set; }
    public ICollection<Product>? Products { get; set; } = new List<Product>();
    public ICollection<Discount>? Discounts { get; set; } = new List<Discount>();
    public ICollection<Category>? categories { get; set; } = new List<Category>();


}
