namespace OnlineShoppingStore.Models;

public class Category
{
    public int CategoryId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public ICollection<Admin>Admins { get; set; } = new List<Admin>();
    public ICollection<Product> Products { get; set; } = new List<Product>();
}
