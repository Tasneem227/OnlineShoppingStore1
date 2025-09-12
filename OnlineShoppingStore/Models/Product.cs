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

    public ICollection<Admin>? Admins = new List<Admin>();

    public ICollection<CartItem>? CartItems = new List<CartItem>();

    public ICollection<Review>? Reviews = new List<Review>();

    public ICollection<Discount>? Discounts = new List<Discount>();

    public ICollection<OrderItem>? OrderItems = new List<OrderItem>();

    public ICollection<Order>? Orders = new List<Order>();
    public int CategoryId { get; set; }
    public Category Category { get; set; }

}