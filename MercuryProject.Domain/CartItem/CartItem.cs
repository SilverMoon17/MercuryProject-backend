using MercuryProject.Domain.CartItem.ValueObjects;
using MercuryProject.Domain.Common.Models;
using MercuryProject.Domain.Product.ValueObjects;
using MercuryProject.Domain.ShoppingCart.ValueObjects;

namespace MercuryProject.Domain.CartItem
{
    public class CartItem : AggregateRoot<CartItemId>
    {
        public int Quantity { get; set; }
        public decimal Price { get; set; }

        public ShoppingCartId ShoppingCartId { get; set; } = null!;
        public ShoppingCart.ShoppingCart ShoppingCart { get; set; } = null!;
        public ProductId ProductId { get; set; } = null!;
        public Product.Product Product { get; set; } = null!;

        public CartItem(CartItemId cartItemId, int quantity, decimal price, ShoppingCartId shoppingCartId, ProductId productId) : base(cartItemId)
        {
            Quantity = quantity;
            Price = price;
            ShoppingCartId = shoppingCartId;
            ProductId = productId;
        }

        public static CartItem Create
            (int quantity, decimal price, ShoppingCartId shoppingCartId, ProductId productId)
        {
            return new(CartItemId.CreateUnique(), quantity, price, shoppingCartId, productId);
        }

        public CartItem()
        {
        }
    }
}
