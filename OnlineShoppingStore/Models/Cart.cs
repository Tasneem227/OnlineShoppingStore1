using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineShoppingStore.Models;

public class Cart
{
    public int CartId { get; set; }
    [ForeignKey("Customer")]
    public int CustomerId { get; set; }
    public virtual Customer? Customer { get; set; }
    public virtual ICollection<CartItem>? CartItems { get; set; } = new List<CartItem>();

}
