using Microsoft.AspNetCore.Http;

namespace MercuryProject.Contracts.Idea
{
    public record IdeaCreateRequest
    (
        string Title,
        string Description,
        decimal Goal,
        string Category,
        List<IFormFile>? Files
    );
}
