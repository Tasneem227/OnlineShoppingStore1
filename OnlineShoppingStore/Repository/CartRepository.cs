namespace OnlineShoppingStore.Repository;

public class CartRepository:ICartRepository
{
    private readonly ApplicationDbContext _Context;

    public CartRepository(ApplicationDbContext context)
    {
        _Context = context;
    }

    public void AddToCart(int productId)
    { 
        CartItem cartItem = new CartItem
        {
            Quantity = 1,
            CartId = 1, // Assuming a default cart ID for demonstration purposes
            ProductId = productId
            
        };
        _Context.CartItems.Add(cartItem);
    }
    public void SaveChanges() =>  _Context.SaveChanges();
}
