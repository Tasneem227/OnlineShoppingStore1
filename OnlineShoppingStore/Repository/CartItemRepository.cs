namespace OnlineShoppingStore.Repository;

public class CartItemRepository: ICartItemRepository
{
    private readonly ApplicationDbContext context;

    public CartItemRepository(ApplicationDbContext _context)
    {
        context = _context;
    }

    public List<CartItem> ShowCartItems(int cartId)
    {
        var CartItems= context.CartsItems.Where(i=>i.CartId==cartId).ToList();
        return CartItems;
    }
}