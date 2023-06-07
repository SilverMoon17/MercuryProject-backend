using MercuryProject.Domain.Idea;
using MercuryProject.Domain.Idea.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MercuryProject.Infrastructure.Persistence.Configurations
{
    public class IdeaConfiguration : IEntityTypeConfiguration<Idea>
    {
        public void Configure(EntityTypeBuilder<Idea> builder)
        {
            ConfigureIdeaTable(builder);
        }

        private void ConfigureIdeaTable(EntityTypeBuilder<Idea> builder)
        {
            builder.ToTable("Ideas");
            builder.HasKey(i => i.Id);

            builder.Property(i => i.Id)
                .ValueGeneratedNever()
                .HasConversion(id => id.Value, value => IdeaId.Create(value));

            builder.HasOne(i => i.User)
                .WithMany(u => u.Ideas)
                .HasForeignKey(i => i.OwnerId)
                .OnDelete(DeleteBehavior.Cascade);

            var valueComparer = new ValueComparer<IReadOnlyList<string>>((c1, c2) => c1.SequenceEqual(c2),
                c => c.Aggregate(0, (a, v) => HashCode.Combine(a, v.GetHashCode())),
                c => c.ToList());

            builder.Property(i => i.IdeaImageUrls)
                .HasConversion(v => string.Join(';', v),
                    v => v.Split(';', StringSplitOptions.RemoveEmptyEntries).ToList())
                .Metadata
                .SetValueComparer(valueComparer);
            builder.Property(i => i.Goal).HasPrecision(18, 2);
            builder.Property(i => i.Collected).HasPrecision(18, 2);
        }
    }
}
