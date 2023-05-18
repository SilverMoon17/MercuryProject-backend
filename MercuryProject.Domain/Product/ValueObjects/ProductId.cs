using MercuryProject.Domain.Common.Models;

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
