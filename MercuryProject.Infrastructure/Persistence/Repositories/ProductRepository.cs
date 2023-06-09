using Azure.Core;
using MercuryProject.Application.Common.Interfaces.Persistence;
using MercuryProject.Domain.Product;
using MercuryProject.Domain.Product.ValueObjects;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

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
                string projectPath = AppDomain.CurrentDomain.BaseDirectory;
                string solutionPath = projectPath;
                while (!Directory.GetFiles(solutionPath, "*.sln").Any())
                {
                    solutionPath = Directory.GetParent(solutionPath)?.FullName;
                    if (solutionPath == null)
                    {
                        break;
                    }
                }

                string folderPath = Directory.GetParent(solutionPath).FullName;
                string targetFolderPath = "MercuryProject-frontend-Own\\src\\resources";
                string absolutePath = Path.Combine(folderPath, targetFolderPath);

                string saveFolderName = Path.Combine("productImages", Regex.Replace(product.Name, @"[^0-9a-zA-Z ]+", "").Replace(" ", "_"));

                string uploadPath = Path.Combine(absolutePath, saveFolderName);

                if (Directory.Exists(uploadPath))
                {
                    Directory.Delete(uploadPath, true);
                }

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
