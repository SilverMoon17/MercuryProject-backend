using MercuryProject.Domain.ShoppingCart;
using MercuryProject.Domain.User.ValueObjects;
using System.Linq.Expressions;

namespace MercuryProject.Application.Common.Interfaces.Persistence
{
    public interface IShoppingCartRepository
    {
        Task<IEnumerable<Domain.ShoppingCart.ShoppingCart>> GetByCustomerIdAsync(Expression<Func<Domain.ShoppingCart.ShoppingCart, bool>> predicate);
        public Task AddAsync(Domain.ShoppingCart.ShoppingCart shoppingCart);
        public Task<Domain.ShoppingCart.ShoppingCart?> GetActiveShoppingCartAsync(UserId id, decimal total = 0);
    }
}
