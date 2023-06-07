using ErrorOr;
using MediatR;

namespace MercuryProject.Application.Idea.Commands.Delete
{
    public record IdeaDeleteCommand(string Id) : IRequest<ErrorOr<bool>>;
}
