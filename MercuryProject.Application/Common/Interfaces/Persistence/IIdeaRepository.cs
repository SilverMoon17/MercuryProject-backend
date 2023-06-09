using MercuryProject.Domain.Enums;
using System.Linq.Expressions;

namespace MercuryProject.Application.Common.Interfaces.Persistence
{
    public interface IIdeaRepository
    {
        Task<Domain.Idea.Idea?> GetIdeaByTitle(string title);
        Task<Domain.Idea.Idea?> GetIdeaById(Guid id);
        Task<bool> DeleteIdea(Domain.Idea.Idea idea);
        Task<IEnumerable<Domain.Idea.Idea>> GetAllIdeasAsync();
        Task<IEnumerable<Domain.Idea.Idea>> GetAllWhereAsync(Expression<Func<Domain.Idea.Idea, bool>> predicate);
        public void UpdateIdeaCollectedMoney(Domain.Idea.Idea idea, decimal donate);
        public void UpdateIdeaStatus(Domain.Idea.Idea idea, IdeaStatus status);
        void Add(Domain.Idea.Idea idea);
    }
}
