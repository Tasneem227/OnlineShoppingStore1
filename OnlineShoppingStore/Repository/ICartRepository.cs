using Microsoft.EntityFrameworkCore;
using OnlineShoppingStore.Models;

namespace OnlineShoppingStore.Repository;

public interface ICartRepository
{
    public void AddToCart(int productId,int CartId);
    public void DeleteItem(int cartItemId, int cartid);

    public void SaveChanges();
}
