using MercuryProject.Domain.Common.Models;

namespace MercuryProject.Domain.CartItem.ValueObjects
{
    public sealed class CartItemId : ValueObject
    {
        public Guid Value { get; }
        private CartItemId(Guid value)
        {
            Value = value;
        }

        public static CartItemId CreateUnique()
        {
            return new(Guid.NewGuid());
        }

        public static CartItemId Create(Guid value)
        {
            return new(value);
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
