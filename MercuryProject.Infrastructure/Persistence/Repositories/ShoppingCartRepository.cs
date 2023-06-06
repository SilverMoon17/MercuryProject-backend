using MercuryProject.Application.Common.Interfaces.Persistence;
using MercuryProject.Domain.Enums;
using MercuryProject.Domain.ShoppingCart;
using MercuryProject.Domain.User.ValueObjects;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace MercuryProject.Infrastructure.Persistence.Repositories
{
    public class ShoppingCartRepository : IShoppingCartRepository
    {
        private readonly MercuryProjectDbContext _dbContext;

        public ShoppingCartRepository(MercuryProjectDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(ShoppingCart shoppingCart)
        {
            await _dbContext.Set<ShoppingCart>().AddAsync(shoppingCart);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<ShoppingCart>> GetByCustomerIdAsync(Expression<Func<ShoppingCart, bool>> predicate)
        {
            return await _dbContext.ShoppingCarts.Include(x => x.CartItems).ThenInclude(x => x.Product).Include(x => x.Customer)
                .Where(predicate)
                .ToListAsync();
        }

        public async Task<ShoppingCart?> GetActiveShoppingCartAsync(UserId id, decimal total = 0)
        {
            var result =
                await GetByCustomerIdAsync(x =>
                    x.CustomerId == id && x.CartState == CartStates.Active);
            if (result.Any())
            {
                var toReturn = result.First();
                toReturn.Total = CalculateFullPrice(toReturn);
                return toReturn;
            }

            await AddAsync(ShoppingCart.Create(id, total));
            result = await GetByCustomerIdAsync(x =>
                x.CustomerId == id && x.CartState == CartStates.Active);
            return result.First();
        }

        private decimal CalculateFullPrice(ShoppingCart cart)
        {
            decimal sum = 0;
            for (var i = 0; i < cart.CartItems.Count(); i++)
            {
                sum += cart.CartItems.ElementAt(i).Price;
            }
            return sum;
        }
    }
}
