namespace OnlineShoppingStore.Models;

public class Product
{
    public int ProductId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public int StockQuantity { get; set; }
    public string Brand { get; set; }
    public string ImageUrl { get; set; }

    public virtual ICollection<Admin>? Admins { get; set; } = new List<Admin>();

    public virtual ICollection<CartItem>? CartItems { get; set; } = new List<CartItem>();

    public virtual ICollection<Review>? Reviews { get; set; } = new List<Review>();

    public virtual ICollection<Discount>? Discounts { get; set; } = new List<Discount>();

    public virtual ICollection<OrderItem>? OrderItems { get; set; } = new List<OrderItem>();

    public virtual ICollection<Order>? Orders { get; set; } = new List<Order>();
    public int CategoryId { get; set; }
    public virtual Category? Category { get; set; }

}