using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.Api.Data
{
    public class ECommerceDbContext : IdentityDbContext
    {
        public ECommerceDbContext(DbContextOptions<ECommerceDbContext> options) : base(options)
        {

        }
        DbSet<Category> Categories { get; set; }
        DbSet<Product> Products { get; set; }
        DbSet<CartItem> CartItems { get; set; }
        DbSet<OrderItem> OrderItems { get; set; }
        DbSet<Cart> Carts { get; set; }
        DbSet<Order> Orders { get; set; }
        DbSet<User> Users { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasIndex(u => u.Name).IsUnique();
            modelBuilder.Entity<User>().HasIndex(u => u.Email).IsUnique();
        }
    }

}
