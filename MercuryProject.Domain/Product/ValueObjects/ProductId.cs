using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MercuryProject.Domain.Common.Models;
using MercuryProject.Domain.User.ValueObjects;

namespace MercuryProject.Domain.Product.ValueObjects
{
    public sealed class ProductId : ValueObject
    {

        public Guid Value { get; }
        private ProductId(Guid value)
        {
            Value = value;
        }

        public static ProductId CreateUnique()
        {
            return new(Guid.NewGuid());
        }

        public static ProductId Create(Guid value)
        {
            return new(value);
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
