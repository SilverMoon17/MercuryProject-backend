using MercuryProject.Domain.CartItem;
using MercuryProject.Domain.CartItem.ValueObjects;
using MercuryProject.Domain.Product.ValueObjects;
using MercuryProject.Domain.ShoppingCart.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MercuryProject.Infrastructure.Persistence.Configurations
{
    public class CartItemConfiguration : IEntityTypeConfiguration<CartItem>
    {
        public void Configure(EntityTypeBuilder<CartItem> builder)
        {
            ConfigureCartItemTable(builder);
        }

        private void ConfigureCartItemTable(EntityTypeBuilder<CartItem> builder)
        {
            builder.ToTable("CartItems");
            builder.HasKey(ci => ci.Id);

            builder.Property(ci => ci.Id)
                .ValueGeneratedNever()
                .HasConversion(id => id.Value, value => CartItemId.Create(value));
            builder.Property(ci => ci.ProductId)
                .ValueGeneratedNever()
                .HasConversion(id => id.Value, value => ProductId.Create(value));
            builder.Property(ci => ci.ShoppingCartId)
                .ValueGeneratedNever()
                .HasConversion(id => id.Value, value => ShoppingCartId.Create(value));
            builder.Property(ci => ci.Price).HasPrecision(18, 2);
            builder
                .HasOne(c => c.Product)
                .WithMany()
                .HasForeignKey(c => c.ProductId);
        }
    }
}
