using MercuryProject.Domain.CartItem.ValueObjects;

namespace MercuryProject.Application.Common.Interfaces.Persistence
{
    public interface ICartItemRepository
    {
        Task<Domain.CartItem.CartItem> GetCartItemById(CartItemId id);
        Task AddAsync(Domain.CartItem.CartItem cartItem);
        Task RemoveAsync(Domain.CartItem.CartItem cartItem);

        Task UpdateAsync(Domain.CartItem.CartItem cartItem);

    }
}
