using Microsoft.EntityFrameworkCore;

namespace OnlineShoppingStore.Repository;

public interface IProductRepository
{
    public List<Product> GetAll();
    public Product GetById(int id);
    public void Add(Product product);
    public void Update(Product product);
    public void Delete(Product product);
    public void SaveChanges();
    public bool ProductExists(string name);
    public List<Product> GetProductByCategryId(int CategoryId);
    public List<Product> GetByName(string name);
}
