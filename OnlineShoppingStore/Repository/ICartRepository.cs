using Microsoft.EntityFrameworkCore;
using OnlineShoppingStore.Models;

namespace OnlineShoppingStore.Repository;

public interface ICartRepository
{
    public void AddToCart(int productId, int CartId, int Quantity);
    public void DeleteItem(int cartItemId, int cartid);

    public void UpdateCartItem(CartItem[] itemslist);

    public void EditQuantity(int Quantity, int ProductId);
    public void AddCart(int customerid);
    public int GetLastCartId();

    public void SaveChanges();
}
