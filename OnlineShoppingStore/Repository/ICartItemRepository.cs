namespace OnlineShoppingStore.Repository;

public interface ICartItemRepository
{
    public List<CartItem> ShowCartItems(int cartId) ;

}
