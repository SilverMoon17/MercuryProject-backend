using MediatR;
using System.Linq.Expressions;

namespace MercuryProject.Application.Idea.Queries.GetAllIdeas
{
    public record GetAllIdeasQuery
        (Expression<Func<Domain.Idea.Idea, bool>> Predicate) : IRequest<IEnumerable<Domain.Idea.Idea>>;
}
