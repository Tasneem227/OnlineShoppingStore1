using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineShoppingStore.Models;

public class Cart
{
    public int CartId { get; set; }
    [ForeignKey("Customer")]
    public int CustomerId { get; set; }
    public Customer Customer { get; set; }
    public ICollection<CartItem>? CartItems { get; set; } = new List<CartItem>();

}
