using OnlineShoppingStore.Models;

namespace OnlineShoppingStore.Repository;

public class CartRepository:ICartRepository
{
    private readonly ApplicationDbContext _Context;

    public CartRepository(ApplicationDbContext context)
    {
        _Context = context;
    }

    public void AddToCart(int productId,int CartId)
    { 
        CartItem cartItem = new CartItem
        {
            Quantity = 1,
            
            ProductId = productId
            
        };
        _Context.CartsItems.Add(cartItem);
    }
    public void DeleteItem(int cartItemId, int cartid)
    {
        var item = _Context.CartsItems.FirstOrDefault(x => x.Id == cartItemId && x.CartId == cartid);
        if (item != null)
        {
            _Context.CartsItems.Remove(item);
            _Context.SaveChanges();
        }
    }
    public void SaveChanges() =>  _Context.SaveChanges();
}
