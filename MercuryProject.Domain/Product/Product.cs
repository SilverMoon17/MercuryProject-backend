using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MercuryProject.Domain.Common.Models;
using MercuryProject.Domain.Enums;
using MercuryProject.Domain.Product.ValueObjects;
using MercuryProject.Domain.User.ValueObjects;

namespace MercuryProject.Domain.Product
{
    public sealed class Product : AggregateRoot<ProductId>
    {

        public UserId UserId { get; }
        public string Name { get; }
        public string Description { get; }
        public int Stock { get; }
        public ProductCategories Category { get; }
        public string IconUrl { get; }
        public DateTime CreatedDateTime { get; }
        public DateTime UpdatedDateTime { get; }
        public Product(ProductId productId, UserId userId, string name, string description, int stock, ProductCategories category, string iconUrl, DateTime createdDateTime, DateTime updatedDateTime) : base(productId)
        {
            UserId = userId;
            Name = name;
            Description = description;
            Stock = stock;
            Category = category;
            IconUrl = iconUrl;
            CreatedDateTime = createdDateTime;
            UpdatedDateTime = updatedDateTime;
        }

        public static Product Create
            (UserId userId, string name, string description, int stock, ProductCategories category, string iconUrl)
        {
            return new(ProductId.CreateUnique(), userId, name, description, stock, category, iconUrl, DateTime.UtcNow,
                DateTime.UtcNow);
        }
    }
}
