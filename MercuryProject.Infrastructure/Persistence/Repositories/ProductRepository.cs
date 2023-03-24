using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MercuryProject.Application.Common.Interfaces.Persistence;
using MercuryProject.Domain.Product;
using Microsoft.EntityFrameworkCore;

namespace MercuryProject.Infrastructure.Persistence.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly MercuryProjectDbContext _dbContext;

        public ProductRepository(MercuryProjectDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Product> GetProductByName(string name)
        {
            return await _dbContext.Set<Product>().FirstOrDefaultAsync(u => u.Name == name);
        }

        public void Add(Product product)
        {
            _dbContext.AddAsync(product);
            _dbContext.SaveChangesAsync();
        }
    }
}
