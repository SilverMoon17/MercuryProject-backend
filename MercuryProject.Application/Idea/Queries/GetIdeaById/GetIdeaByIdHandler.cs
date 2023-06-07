using ErrorOr;
using MediatR;
using MercuryProject.Application.Common.Interfaces.Persistence;
using MercuryProject.Application.Idea.Common;
using MercuryProject.Domain.Common.Errors;

namespace MercuryProject.Application.Idea.Queries.GetIdeaById
{
    public class GetIdeaByIdHandler : IRequestHandler<GetIdeaByIdQuery, ErrorOr<IdeaResult>>
    {
        private readonly IIdeaRepository _ideaRepository;

        public GetIdeaByIdHandler(IIdeaRepository ideaRepository)
        {
            _ideaRepository = ideaRepository;
        }

        public async Task<ErrorOr<IdeaResult>> Handle(GetIdeaByIdQuery query, CancellationToken cancellationToken)
        {
            if (Guid.TryParse(query.Id, out var ideaGuid))
            {
                var product = await _ideaRepository.GetIdeaById(ideaGuid);

                if (product is null)
                {
                    return Errors.Idea.IdeaNotFound;
                }

                return new IdeaResult(product);
            }

            return Errors.Idea.CorrectId;
        }
    }
}
