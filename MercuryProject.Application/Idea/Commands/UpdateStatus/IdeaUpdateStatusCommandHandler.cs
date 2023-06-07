using ErrorOr;
using MediatR;
using MercuryProject.Application.Common.Interfaces.Persistence;
using MercuryProject.Application.Idea.Commands.Approve;
using MercuryProject.Domain.Common.Errors;

namespace MercuryProject.Application.Idea.Approve
{
    public class IdeaUpdateStatusCommandHandler : IRequestHandler<IdeaUpdateStatusCommand, ErrorOr<Domain.Idea.Idea>>
    {
        private readonly IIdeaRepository _ideaRepository;

        public IdeaUpdateStatusCommandHandler(IIdeaRepository ideaRepository)
        {
            _ideaRepository = ideaRepository;
        }

        public async Task<ErrorOr<Domain.Idea.Idea>> Handle(IdeaUpdateStatusCommand request, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;
            if (Guid.TryParse(request.Id, out var ideaGuid))
            {
                var idea = await _ideaRepository.GetIdeaById(ideaGuid);

                if (idea is null)
                {
                    return Errors.Idea.IdeaNotFound;
                }

                if (idea.Status == request.Status)
                {
                    return Errors.Idea.Status;
                }
                _ideaRepository.UpdateIdeaStatus(idea, request.Status);
                return idea;
            }

            return Errors.Idea.CorrectId;

        }
    }
}
