using FluentValidation;

namespace MercuryProject.Application.Idea.Create
{
    public class IdeaCreateCommandValidator : AbstractValidator<IdeaCreateCommand>
    {
        public IdeaCreateCommandValidator()
        {
            RuleFor(i => i.Title).NotEmpty().WithMessage("Title is required field");
            RuleFor(i => i.Description).NotEmpty();
            RuleFor(i => i.Category).NotEmpty();
            RuleFor(i => i.IconUrls).NotEmpty();
            RuleFor(i => i.Goal).GreaterThanOrEqualTo(1000).WithMessage("Goal must be equal or greater than 1000$").NotEmpty();
        }
    }
}
