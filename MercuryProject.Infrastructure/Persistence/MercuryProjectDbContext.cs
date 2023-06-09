using MercuryProject.Domain.CartItem;
using MercuryProject.Domain.Idea;
using MercuryProject.Domain.Order;
using MercuryProject.Domain.Product;
using MercuryProject.Domain.ShoppingCart;
using MercuryProject.Domain.User;
using Microsoft.EntityFrameworkCore;

namespace MercuryProject.Infrastructure.Persistence
{
    public class MercuryProjectDbContext : DbContext
    {
        public MercuryProjectDbContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Product> Products { get; set; } = null!;
        public DbSet<Idea> Ideas { get; set; } = null!;
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MercuryProjectDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
