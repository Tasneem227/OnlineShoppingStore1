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

    public virtual ICollection<Admin>? Admins { get; set; } = new List<Admin>();

    public virtual ICollection<Product>? Products { get; set; } = new List<Product>();


}