using OnlineShoppingStore.Enum;

namespace OnlineShoppingStore.Models;

public class Customer
{
    public int CustomerId { get; set; }
    public string UserId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateOnly DateOfBirth { get; set; }
    public Gender Gender { get; set; }
    public string Address { get; set; }
    public string PhoneNumber { get; set; }
    public string Image { get; set; }

    public virtual ICollection<Order>? Orders { get; set; } = new List<Order>();
    public virtual ICollection<Review>? Reviews { get; set; } = new List<Review>();
    
}
