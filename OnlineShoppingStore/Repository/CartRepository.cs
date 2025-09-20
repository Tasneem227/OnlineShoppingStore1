using OnlineShoppingStore.Data;

namespace OnlineShoppingStore.Repository;

public class CartRepository : ICartRepository
{
    private readonly ApplicationDbContext _Context;

    public CartRepository(ApplicationDbContext context)
    {
        _Context = context;
    }

    public void AddToCart(int ProductId, int CartId, int Quantity)
    {
        CartItem cartItem = new CartItem
        {
            ProductId = ProductId,
            CartId = CartId,
            Quantity = Quantity

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

    public void UpdateCartItem(CartItem[] itemsList)
    {
        foreach (var item in itemsList)
        {
            var existingItem = _Context.CartsItems.FirstOrDefault(c => c.Id == item.Id);
            if (existingItem != null)
            {
                existingItem.Quantity = item.Quantity;
                existingItem.ProductId = item.ProductId;
                existingItem.CartId = item.CartId;
            }
        }

        _Context.SaveChanges();
    }

    public void EditQuantity(int Quantity, int ProductId)
    {
        var result = _Context.CartsItems.FirstOrDefault(e => e.ProductId == ProductId);
        result.Quantity = Quantity;
    }

    public void AddCart(int customerid)
    {
        Cart cart = new Cart
        {
            CustomerId = customerid
        };
        _Context.Carts.Add(cart);
    }
    public int GetLastCartId()
    {
        return _Context.Carts.Max(c => c.CartId);
    }   
    public void SaveChanges() => _Context.SaveChanges();
}
