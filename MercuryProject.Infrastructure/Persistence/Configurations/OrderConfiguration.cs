using MercuryProject.Domain.Order;
using MercuryProject.Domain.Order.ValueObjects;
using MercuryProject.Domain.ShoppingCart.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MercuryProject.Infrastructure.Persistence.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            ConfigureOrderTable(builder);
        }

        private void ConfigureOrderTable(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Orders");
            builder.HasKey(o => o.Id);

            builder.Property(o => o.Id)
                .ValueGeneratedNever()
                .HasConversion(id => id.Value, value => OrderId.Create(value));
            builder.Property(o => o.ShoppingCartId)
                .ValueGeneratedNever()
                .HasConversion(id => id.Value, value => ShoppingCartId.Create(value));
            builder.Property(o => o.Price).HasPrecision(18, 2);

        }
    }
}
