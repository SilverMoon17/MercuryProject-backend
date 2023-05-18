using MercuryProject.Domain.Common.Models;

namespace MercuryProject.Domain.Idea.ValueObjects
{
    public sealed class IdeaId : ValueObject
    {

        public Guid Value { get; }
        private IdeaId(Guid value)
        {
            Value = value;
        }

        public static IdeaId CreateUnique()
        {
            return new(Guid.NewGuid());
        }

        public static IdeaId Create(Guid value)
        {
            return new(value);
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
