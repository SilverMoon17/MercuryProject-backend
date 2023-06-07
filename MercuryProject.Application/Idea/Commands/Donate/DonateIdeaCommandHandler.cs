using ErrorOr;
using MediatR;
using MercuryProject.Application.Common.Interfaces.Persistence;
using MercuryProject.Domain.Common.Errors;

namespace MercuryProject.Application.Idea.Commands.Donate
{
    internal class DonateIdeaCommandHandler : IRequestHandler<DonateIdeaCommand, ErrorOr<Domain.Idea.Idea>>
    {
        private readonly IIdeaRepository _ideaRepository;

        public DonateIdeaCommandHandler(IIdeaRepository ideaRepository)
        {
            _ideaRepository = ideaRepository;
        }

        public async Task<ErrorOr<Domain.Idea.Idea>> Handle(DonateIdeaCommand request, CancellationToken cancellationToken)
        {
            if (Guid.TryParse(request.Id, out var ideaGuid))
            {
                var idea = await _ideaRepository.GetIdeaById(ideaGuid);

                if (idea is null)
                {
                    return Errors.Idea.IdeaNotFound;
                }

                _ideaRepository.UpdateIdeaCollectedMoney(idea, request.Donate);
                return idea;
            }

            return Errors.Idea.CorrectId;
        }
    }
}
