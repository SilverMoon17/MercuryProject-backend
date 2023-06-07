using FluentValidation;

namespace MercuryProject.Application.Idea.Commands.Delete
{
    public class IdeaDeleteCommandValidator : AbstractValidator<IdeaDeleteCommand>
    {
        public IdeaDeleteCommandValidator()
        {
            RuleFor(p => p.Id).NotEmpty().WithMessage("Specify the id");
        }
    }
}
