using MercuryProject.Domain.Product.ValueObjects;
using MercuryProject.Domain.ShoppingCart.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MercuryProject.Domain.CartItem.ValueObjects;
using MercuryProject.Domain.Product.Dto;

namespace MercuryProject.Domain.CartItem.Dto
{
    public class CartItemDto
    {
        public Guid CartItemId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public ProductDto Product { get; set; } = null!;
    }
}
