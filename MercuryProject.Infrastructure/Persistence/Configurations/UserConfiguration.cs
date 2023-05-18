using MercuryProject.Domain.User;
using MercuryProject.Domain.User.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace MercuryProject.Infrastructure.Persistence.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            ConfigureUserTable(builder);
        }

        private void ConfigureUserTable(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");

            builder.HasKey(u => u.Id);

            builder.Property(m => m.Id)
                .ValueGeneratedNever()
                .HasConversion(id => id.Value,
                    value => UserId.Create(value));

            builder.Property(u => u.Username).HasMaxLength(30);
            builder.Property(u => u.Fullname).HasMaxLength(100);
            //builder.OwnsMany(u => u.Ideas, ib =>
            //{
            //    ib.ToTable("Ideas");

            //    ib.HasKey(i => i.Id);

            //    ib.Property(i => i.Id)
            //        .ValueGeneratedNever()
            //        .HasConversion(id => id.Value, value => IdeaId.CreateUnique());

            //});
            //builder.Metadata.FindNavigation(nameof(User.Ideas))!
            //    .SetPropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}
