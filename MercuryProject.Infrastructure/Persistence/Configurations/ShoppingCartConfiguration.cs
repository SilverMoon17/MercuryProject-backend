using MercuryProject.Domain.ShoppingCart;
using MercuryProject.Domain.ShoppingCart.ValueObjects;
using MercuryProject.Domain.User.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MercuryProject.Infrastructure.Persistence.Configurations
{
    public class ShoppingCartConfiguration : IEntityTypeConfiguration<ShoppingCart>
    {
        public void Configure(EntityTypeBuilder<ShoppingCart> builder)
        {
            ConfigureShoppingCartTable(builder);
        }

        private void ConfigureShoppingCartTable(EntityTypeBuilder<ShoppingCart> builder)
        {
            builder.ToTable("ShoppingCarts");
            builder.HasKey(sc => sc.Id);

            builder.Property(sc => sc.Id)
                .ValueGeneratedNever()
                .HasConversion(id => id.Value, value => ShoppingCartId.Create(value));
            builder.Property(sc => sc.CustomerId)
                .ValueGeneratedNever()
                .HasConversion(id => id.Value, value => UserId.Create(value));
            builder.Property(sc => sc.Total).HasPrecision(18, 2);
            //builder.HasOne(sc => sc.Customer)
            //    .WithMany(c => c.ShoppingCarts)
            //    .HasForeignKey(sc => sc.CustomerId)
            //    .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
