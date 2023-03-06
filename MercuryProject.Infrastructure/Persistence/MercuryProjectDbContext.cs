using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MercuryProjectDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
