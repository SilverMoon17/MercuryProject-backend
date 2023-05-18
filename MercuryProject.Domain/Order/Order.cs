using MercuryProject.Domain.Common.Models;
using MercuryProject.Domain.Order.ValueObjects;
using MercuryProject.Domain.ShoppingCart.ValueObjects;

namespace MercuryProject.Domain.Order
{
    public class Order : AggregateRoot<OrderId>
    {
        public decimal Price { get; set; }
        public string Address { get; set; } = null!;

        public ShoppingCartId ShoppingCartId { get; set; }
        public ShoppingCart.ShoppingCart ShoppingCart { get; set; }

        public Order(OrderId orderId, decimal price, string address, ShoppingCartId shoppingCartId) : base(orderId)
        {
            Price = price;
            Address = address;
            ShoppingCartId = shoppingCartId;
        }

        public static Order Create
            (decimal price, string address, ShoppingCartId shoppingCartId)
        {
            return new(OrderId.CreateUnique(), price, address, shoppingCartId);
        }

        public Order()
        {
        }
    }
}
