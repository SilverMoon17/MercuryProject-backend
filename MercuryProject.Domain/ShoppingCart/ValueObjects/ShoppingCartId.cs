using MercuryProject.Domain.Common.Models;

namespace MercuryProject.Domain.ShoppingCart.ValueObjects
{
    public sealed class ShoppingCartId : ValueObject
    {
        public Guid Value { get; }
        private ShoppingCartId(Guid value)
        {
            Value = value;
        }

        public static ShoppingCartId CreateUnique()
        {
            return new(Guid.NewGuid());
        }

        public static ShoppingCartId Create(Guid value)
        {
            return new(value);
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
