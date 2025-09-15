namespace OnlineShoppingStore.Repository;

public class CategoryRepository: ICategoryRepository
{
    private readonly ApplicationDbContext Context;
    public CategoryRepository(ApplicationDbContext context)
    {
        Context = context;
    }

    public List<Category> GetAllCategories()
    {
        return Context.Categories.ToList();
    }
}
