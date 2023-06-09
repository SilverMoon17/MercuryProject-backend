using MercuryProject.Application.Common.Interfaces.Persistence;
using MercuryProject.Domain.CartItem;
using MercuryProject.Domain.CartItem.ValueObjects;
using MercuryProject.Domain.ShoppingCart;
using Microsoft.EntityFrameworkCore;

namespace MercuryProject.Infrastructure.Persistence.Repositories
{
    public class CartItemRepository : ICartItemRepository
    {
        private readonly MercuryProjectDbContext _dbContext;

        public CartItemRepository(MercuryProjectDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<CartItem> GetCartItemById(CartItemId id)
        {
            return await _dbContext.Set<CartItem>().FirstOrDefaultAsync(ci => ci.Id == id);
        }

        public async Task AddAsync(CartItem cartItem)
        {
            await _dbContext.Set<CartItem>().AddAsync(cartItem);
            await _dbContext.SaveChangesAsync();
        }

        public async Task RemoveAsync(CartItem cartItem)
        { 
            _dbContext.Remove(cartItem);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(CartItem cartItem)
        {
            _dbContext.Update(cartItem);
            await _dbContext.SaveChangesAsync();
        }
    }
}
