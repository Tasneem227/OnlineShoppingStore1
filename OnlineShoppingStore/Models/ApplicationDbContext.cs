using Microsoft.EntityFrameworkCore;

namespace OnlineShoppingStore.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() : base()
        {

        }
        public DbSet<Admin> Admin { get; set; }

        public DbSet<Cart> Cart { get; set; }
        public DbSet<Order> Order { get; set; }
       public DbSet<CartItem> CartItem { get; set; }

        public DbSet<Category> Category { get; set; }

        public DbSet<Customer> Customer { get; set; }
        public DbSet<OrderItem> OrderItem { get; set; }
        public DbSet<Discount> Discount { get; set; }
        public DbSet<Product> Product { get; set; }

        public DbSet<Review> Review { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=SHAHDMAHMOUD;Initial Catalog=Online_Shopping_Store;Integrated Security=True;Trust Server Certificate=True");
            base.OnConfiguring(optionsBuilder);
        }







    }
}
