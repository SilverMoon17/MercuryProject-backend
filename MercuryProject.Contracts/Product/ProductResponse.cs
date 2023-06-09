using MercuryProject.Domain.User.ValueObjects;
using Microsoft.AspNetCore.Http;

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
        IReadOnlyList<string>? ProductImageUrls,
        DateTime CreatedDateTime,
        DateTime UpdatedDateTime
    );
}
