namespace OnlineShoppingStore.Models;

public class Order
{
    public int OrderId { get; set; }
    public DateTime OrderDate { get; set; }
    public string Status { get; set; }
    public decimal TotalAmount { get; set; }

    public ICollection<OrderItem>? OrderItems = new List<OrderItem>();

    public ICollection<Product>? Products = new List<Product>();

    public int CustomerId { get; set; }
    public Customer Customer { get; set; }




}