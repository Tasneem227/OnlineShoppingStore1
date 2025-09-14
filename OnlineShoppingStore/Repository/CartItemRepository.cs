namespace OnlineShoppingStore.Repository;

public class CartItemRepository: ICartItemRepository
{
    private readonly ApplicationDbContext context;

    public CartItemRepository(ApplicationDbContext _context)
    {
        context = _context;
    }
    public List<CartItem> ShowCart()=> context.CartItems.ToList();

}