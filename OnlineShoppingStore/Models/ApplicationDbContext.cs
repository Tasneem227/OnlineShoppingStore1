using Microsoft.EntityFrameworkCore;

namespace OnlineShoppingStore.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() : base()
        {

        }
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Admin> Admins { get; set; }

        public DbSet<Cart> Carts { get; set; }
        public DbSet<Order> Orders { get; set; }
       public DbSet<CartItem> CartItems { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Discount> Discounts { get; set; }
        public DbSet<Product> Products { get; set; }

        public DbSet<Review> Reviews { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Data Source=PC-1\\SQLEXPRESS;Initial Catalog=Online_Shopping_Store;Integrated Security=True;Trust Server Certificate=True");
        //    base.OnConfiguring(optionsBuilder);
        //}







    }
}
