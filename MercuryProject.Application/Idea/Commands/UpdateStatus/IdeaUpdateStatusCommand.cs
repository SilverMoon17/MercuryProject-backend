using ErrorOr;
using MediatR;
using MercuryProject.Domain.Enums;

namespace MercuryProject.Application.Idea.Commands.Approve
{
    public record IdeaUpdateStatusCommand(string Id, IdeaStatus Status) : IRequest<ErrorOr<Domain.Idea.Idea>>;
}
