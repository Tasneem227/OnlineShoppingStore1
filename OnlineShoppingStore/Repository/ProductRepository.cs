
using OnlineShoppingStore.Data;

namespace OnlineShoppingStore.Repository;

public class ProductRepository : IProductRepository
{
    ApplicationDbContext _Context;
    public ProductRepository(ApplicationDbContext context)
    {
        this._Context = context;
    }

    public List<Product> GetAll()
    {
        return _Context.Products
                  .Include(c => c.Category)
                  .OrderBy(p => Guid.NewGuid()) // random order
                  .ToList();
    }

    public Product GetById(int id)
    {
        return _Context.Products.Include(c=>c.Category).FirstOrDefault(p => p.ProductId == id);
    }
    public void Add(Product product)
    {
        _Context.Products.Add(product);
        _Context.SaveChanges();
    }
    public void Update(Product product)
    {
        _Context.Products.Update(product);
        _Context.SaveChanges();
    }
    public void Delete(Product product)
    {
        if (product != null)
        {
            _Context.Products.Remove(product);
            _Context.SaveChanges();
        }
    }

    public List<Product> GetProductByCategryId(int CategoryId)
    {

        var list = _Context.Products
                            .Where(p => p.CategoryId == CategoryId)
                            .ToList();

        return list;
    }
    public void SaveChanges() => _Context.SaveChanges();
    public bool ProductExists(string name) => _Context.Products.Any(e => e.Name.Equals(name));
    public List<Product> GetByName(string name)
    {
        return _Context.Products.Include(c => c.Category)
                       .Where(p => p.Name.Contains(name))
                       .Include(c => c.Category)
                       .ToList();
    }
}
