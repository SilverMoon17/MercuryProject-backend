using ErrorOr;
using MediatR;

namespace MercuryProject.Application.Idea.Commands.Donate
{
    public record DonateIdeaCommand(string Id, decimal Donate) : IRequest<ErrorOr<Domain.Idea.Idea>>;
}
