using ErrorOr;
using MediatR;
using MercuryProject.Application.Idea.Common;
using Microsoft.AspNetCore.Http;

namespace MercuryProject.Application.Idea.Create
{
    public record IdeaCreateCommand
    (
        string Title,
        string Description,
        decimal Goal,
        string Category,
        List<IFormFile>? Files
    ) : IRequest<ErrorOr<IdeaResult>>;
}
