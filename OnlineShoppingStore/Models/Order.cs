namespace OnlineShoppingStore.Models;

public class Order
{
    public int OrderId { get; set; }
    public DateTime OrderDate { get; set; }
    public OrderStatus Status { get; set; }
    public decimal TotalAmount { get; set; }

    public virtual ICollection<OrderItem>? OrderItems { get; set; } = new List<OrderItem>();

    public virtual ICollection<Product>? Products { get; set; } = new List<Product>();

    public int CustomerId { get; set; }
    public virtual Customer? Customer { get; set; }




}