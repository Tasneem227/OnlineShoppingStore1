
namespace OnlineShoppingStore.Repository;

public class ProductRepository(ApplicationDbContext context):IProductRepository
{
    private readonly ApplicationDbContext _Context = context;

    public List<Product> GetAll() => _Context.Products.Include(c=>c.Category).ToList();
    public Product GetById(int id)
    {
        return _Context.Products.FirstOrDefault(p => p.ProductId == id);
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
    public void Delete(int id)
    {
        var product = GetById(id);
        if (product != null)
        {
            _Context.Products.Remove(product);
            _Context.SaveChanges();
        }
    }
    public void SaveChanges() => _Context.SaveChanges();
    public bool ProductExists(string name) => _Context.Products.Any(e => e.Name.Equals( name));
}
