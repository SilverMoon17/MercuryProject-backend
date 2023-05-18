using MercuryProject.Domain.User.ValueObjects;

namespace MercuryProject.Contracts.Product
{
    public record ProductResponse
    (
        Guid Id,
        UserId UserId,
        string Name,
        string Description,
        decimal Price,
        int Stock,
        string Category,
        string IconUrl,
        DateTime CreatedDateTime,
        DateTime UpdatedDateTime
    );
}
