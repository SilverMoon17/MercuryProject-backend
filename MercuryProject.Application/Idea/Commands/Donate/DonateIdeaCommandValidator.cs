using FluentValidation;

namespace MercuryProject.Application.Idea.Commands.Donate
{
    public class DonateIdeaCommandValidator : AbstractValidator<DonateIdeaCommand>
    {
        public DonateIdeaCommandValidator()
        {
            RuleFor(i => i.Id).NotEmpty();
            RuleFor(i => i.Donate).GreaterThanOrEqualTo(1).NotEmpty();
        }
    }
}
