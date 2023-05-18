﻿using MercuryProject.Domain.Common.Models;
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
        public decimal Price { get; }
        public string Category { get; }
        public string? IconUrl { get; }
        public DateTime CreatedDateTime { get; }
        public DateTime UpdatedDateTime { get; }
        public Product(ProductId productId, UserId userId, string name, string description, decimal price, int stock, string category, string iconUrl, DateTime createdDateTime, DateTime updatedDateTime) : base(productId)
        {
            UserId = userId;
            Name = name;
            Description = description;
            Stock = stock;
            Category = category;
            IconUrl = iconUrl;
            CreatedDateTime = createdDateTime;
            UpdatedDateTime = updatedDateTime;
            Price = price;
        }

        public Product
        (
            string name,
            string description,
            decimal price,
            int stock,
            string category,
            string iconUrl
        )
        {
            Name = name;
            Description = description;
            Price = price;
            Stock = stock;
            Category = category;
            IconUrl = iconUrl;
        }

        public static Product Create
            (UserId userId, string name, string description, decimal price, int stock, string category, string iconUrl)
        {
            return new(ProductId.CreateUnique(), userId, name, description, price, stock, category, iconUrl, DateTime.UtcNow,
                DateTime.UtcNow);
        }

        public Product(UserId userId)
        {
            UserId = userId;
        }

        public Product(){}
    }
}
