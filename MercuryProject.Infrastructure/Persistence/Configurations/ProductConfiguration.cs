using MercuryProject.Domain.Product;
using MercuryProject.Domain.Product.ValueObjects;
using MercuryProject.Domain.User.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MercuryProject.Infrastructure.Persistence.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            ConfigureProductTable(builder);
        }

        private void ConfigureProductTable(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id)
                .ValueGeneratedNever()
                .HasConversion(id => id.Value,
                    value => ProductId.Create(value));

            builder.Property(m => m.UserId)
                .HasConversion(id => id.Value,
                    value => UserId.Create(value));

            builder.Property(p => p.Name).HasMaxLength(150);
            builder.Property(p => p.Description);
            builder.Property(p => p.Stock);
            builder.Property(p => p.Price).HasPrecision(18, 2);
            builder.Property(p => p.Category);
            var valueComparer = new ValueComparer<IReadOnlyList<string>>((c1, c2) => c1.SequenceEqual(c2),
                c => c.Aggregate(0, (a, v) => HashCode.Combine(a, v.GetHashCode())),
                c => c.ToList());

            builder.Property(i => i.ProductImageUrls)
                .HasConversion(v => string.Join(';', v),
                    v => v.Split(';', StringSplitOptions.RemoveEmptyEntries).ToList())
                .Metadata
                .SetValueComparer(valueComparer);
            builder.Property(p => p.CreatedDateTime);
            builder.Property(p => p.UpdatedDateTime);
        }
    }
}
