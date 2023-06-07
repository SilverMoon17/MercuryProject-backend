using ErrorOr;
using MediatR;
using MercuryProject.Application.Idea.Common;

namespace MercuryProject.Application.Idea.Create
{
    public record IdeaCreateCommand
    (
        string Title,
        string Description,
        decimal Goal,
        string Category,
        List<string> IconUrls
    ) : IRequest<ErrorOr<IdeaResult>>;
}
