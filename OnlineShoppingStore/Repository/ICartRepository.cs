using Microsoft.EntityFrameworkCore;

namespace OnlineShoppingStore.Repository;

public interface ICartRepository
{
    public void AddToCart(int productId);
    public void SaveChanges();
}
