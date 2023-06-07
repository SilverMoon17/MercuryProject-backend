using MediatR;
using MercuryProject.Application.Common.Interfaces.Persistence;
using MercuryProject.Domain.Enums;

namespace MercuryProject.Application.Idea.Queries.GetAllIdeas
{
    public class GetAllIdeasQueryHandler : IRequestHandler<GetAllIdeasQuery, IEnumerable<Domain.Idea.Idea>>
    {
        private readonly IIdeaRepository _ideaRepository;

        public GetAllIdeasQueryHandler(IIdeaRepository ideaRepository)
        {
            _ideaRepository = ideaRepository;
        }

        public async Task<IEnumerable<Domain.Idea.Idea>> Handle(GetAllIdeasQuery request, CancellationToken cancellationToken)
        {
            var ideasList = await _ideaRepository.GetAllIdeasAsync();
            var projectList = ideasList.Where(i => i.Status == IdeaStatus.Approved && i.Goal <= i.Collected);

            if (projectList.Any())
            {
                foreach (var project in projectList)
                {
                    _ideaRepository.UpdateIdeaStatus(project, IdeaStatus.Project);
                }
            }

            IEnumerable<Domain.Idea.Idea> list = await _ideaRepository.GetAllWhereAsync(request.Predicate);

            return list;
        }
    }
}
