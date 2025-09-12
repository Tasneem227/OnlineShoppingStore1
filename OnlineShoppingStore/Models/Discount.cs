namespace OnlineShoppingStore.Models;

public class Discount
{
    public int DiscountId { get; set; }
    public string Name { get; set; }
    public string Code { get; set; }
    public decimal Percentage { get; set; }
    public decimal Amount { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public bool IsActive { get; set; }

    public ICollection<Admin>? Admins = new List<Admin>();

    public ICollection<Product>? Products = new List<Product>();


}