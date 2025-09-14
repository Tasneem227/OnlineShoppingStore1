
namespace OnlineShoppingStore.Repository;

public class ProductRepository(ApplicationDbContext context):IProductRepository
{
    private readonly ApplicationDbContext _Context = context;

    public List<Product> GetAll() => _Context.Products.ToList();
    public Product GetById(int id)
    {
        return _Context.Products.FirstOrDefault(p => p.ProductId == id);
    }

}
