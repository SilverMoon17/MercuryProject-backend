using MercuryProject.Domain.User.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MercuryProject.Domain.Product.Dto
{
    public class ProductDto
    {
        public Guid productId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Stock { get; set; }
        public decimal Price { get; set; }
        public string Category { get; set; }
        public List<string>? ProductImageUrls { get; set; }
    }
}
