using MercuryProject.Domain.Common.Models;
using MercuryProject.Domain.Enums;
using MercuryProject.Domain.ShoppingCart.ValueObjects;
using MercuryProject.Domain.User.ValueObjects;

namespace MercuryProject.Domain.ShoppingCart
{
    public class ShoppingCart : AggregateRoot<ShoppingCartId>
    {
        private readonly List<CartItem.CartItem> _cartItems = new();
        public UserId CustomerId { get; set; }
        public User.User Customer { get; set; }
        public IReadOnlyList<CartItem.CartItem> CartItems => _cartItems.AsReadOnly();
        public CartStates CartState { get; set; }
        public decimal Total { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public DateTime UpdatedDateTime { get; set; }

        public ShoppingCart(ShoppingCartId shoppingCartId, UserId customerId, decimal total, DateTime createdDateTime, DateTime updatedDateTime, CartStates cartState = CartStates.Active) : base(shoppingCartId)
        {
            CustomerId = customerId;
            Total = total;
            CreatedDateTime = createdDateTime;
            UpdatedDateTime = updatedDateTime;
            CartState = cartState;
        }

        public static ShoppingCart Create
            (UserId customerId, decimal total)
        {
            return new(ShoppingCartId.CreateUnique(), customerId, total, DateTime.UtcNow,
                DateTime.UtcNow);
        }

        public ShoppingCart()
        {
        }
    }
}
