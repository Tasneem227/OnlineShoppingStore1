namespace OnlineShoppingStore.Repository;

public interface IProductRepository
{
    public List<Product> GetAll();
    public Product GetById(int id);
}
