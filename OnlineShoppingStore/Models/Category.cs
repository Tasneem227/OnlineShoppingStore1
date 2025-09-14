namespace OnlineShoppingStore.Models;

public class Category
{
    public int CategoryId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public virtual ICollection<Admin>?Admins { get; set; } = new List<Admin>();
    public virtual ICollection<Product>? Products { get; set; } = new List<Product>();
}
