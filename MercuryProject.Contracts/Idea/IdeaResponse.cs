using MercuryProject.Domain.Enums;
using MercuryProject.Domain.User.ValueObjects;

namespace MercuryProject.Contracts.Idea
{
    public record IdeaResponse
    (
        Guid Id,
        UserId OwnerId,
        string Title,
        string Description,
        IdeaStatus Status,
        decimal Goal,
        decimal Collected,
        string Category,
        List<string> IdeaImageUrls,
        DateTime CreatedDateTime,
        DateTime UpdatedDateTime
    );
}
