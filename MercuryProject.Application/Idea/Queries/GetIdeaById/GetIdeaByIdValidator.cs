using FluentValidation;

namespace MercuryProject.Application.Idea.Queries.GetIdeaById
{
    public class GetIdeaByIdValidator : AbstractValidator<GetIdeaByIdQuery>
    {
        public GetIdeaByIdValidator()
        {
            RuleFor(i => i.Id).NotEmpty();
        }
    }
}
