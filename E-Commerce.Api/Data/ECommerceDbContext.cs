using E_Commerce.Api.Data.Configuration;
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new RoleConfiguration());

            // Global query filter to exclude soft-deleted users
            // Use IgnoreQueryFilters() to include soft-deleted entities in queries
            modelBuilder.Entity<User>().HasQueryFilter(u => !u.IsDeleted);
            modelBuilder.Entity<Cart>().HasQueryFilter(u => !u.User.IsDeleted);

            modelBuilder.Entity<Category>().HasIndex(u => u.Name).IsUnique();
            modelBuilder.Entity<User>().HasIndex(u => u.Email).IsUnique();

            modelBuilder.Entity<Product>().Property(u => u.Price).HasPrecision(18, 2);
            modelBuilder.Entity<Order>().Property(u => u.TotalAmount).HasPrecision(18, 2);
            modelBuilder.Entity<OrderItem>().Property(u => u.PriceatPurchase).HasPrecision(18, 2);

            modelBuilder.Entity<Order>()
                .HasOne(c => c.User)
                .WithMany(c => c.Orders)
                .HasForeignKey(p => p.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<OrderItem>(entity =>
            {
                entity.HasOne(c => c.Order)
                .WithMany()
                .HasForeignKey(p => p.OrderId)
                .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(c => c.Product)
                .WithMany()
                .HasForeignKey(p => p.ProductId)
                .OnDelete(DeleteBehavior.Restrict);

            });

            modelBuilder.Entity<Product>()
                .HasOne(c => c.Category)
                .WithMany()
                .HasForeignKey(p => p.CategoryId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Cart>()
                .HasOne(c => c.User)
                .WithOne(c => c.Cart)
                .HasForeignKey<Cart>(p => p.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<CartItem>(entity =>
            {
                entity.HasOne(c => c.Cart)
                .WithMany(c => c.CartItems)
                .HasForeignKey(p => p.CartId)
                .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(c => c.Product)
                .WithMany()
                .HasForeignKey(p => p.ProductId)
                .OnDelete(DeleteBehavior.Cascade);
            });
        }
    }

}
