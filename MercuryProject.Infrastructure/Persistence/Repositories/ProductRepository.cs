using MercuryProject.Application.Common.Interfaces.Persistence;
using MercuryProject.Domain.Product;
using MercuryProject.Domain.Product.ValueObjects;
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

        public async Task<Product?> GetProductByName(string name)
        {
            return await _dbContext.Set<Product>().FirstOrDefaultAsync(u => u.Name == name);
        }

        public async Task<Product?> GetProductById(Guid id)
        {
            var productId = ProductId.Create(id);
            var product = await _dbContext.Set<Product>().FirstOrDefaultAsync(p => p.Id == productId);

            return product;
        }

        public async Task<bool> DeleteProduct(Product product)
        {
            try
            {
                _dbContext.Remove(product);
                await _dbContext.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            return await _dbContext.Set<Product>().ToListAsync();
        }

        public void Add(Product product)
        {
            _dbContext.Add(product);
            _dbContext.SaveChanges();
        }
    }
}
