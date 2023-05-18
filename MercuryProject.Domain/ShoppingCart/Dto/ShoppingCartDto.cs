using MercuryProject.Domain.Enums;
using MercuryProject.Domain.User.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MercuryProject.Domain.CartItem.Dto;
using MercuryProject.Domain.ShoppingCart.ValueObjects;

namespace MercuryProject.Domain.ShoppingCart.Dto
{
    public class ShoppingCartDto
    {
        public Guid shoppingCartId { get; set; }
        public UserId CustomerId { get; set; }
        public IReadOnlyList<CartItemDto> CartItems { get; set; }
        public CartStates CartState { get; set; }
        public decimal Total { get; set; }

        public ShoppingCartDto
            (UserId customerId, IReadOnlyList<CartItemDto> cartItems, CartStates cartState, decimal total)
        {
            CustomerId = customerId;
            CartItems = cartItems;
            CartState = cartState;
            Total = total;
        }

        public ShoppingCartDto() {}
    }
}
