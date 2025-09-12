namespace OnlineShoppingStore.Models;

public class Review
{
    public int ReviewId { get; set; }
    public int Rating { get; set; }
    public string Comment { get; set; }
    public DateTime ReviewDate { get; set; }
    public int CustomerId { get; set; }
    public Customer Customer { get; set; }

    public int ProductId { get; set; }
    public Product Product { get; set; }

}