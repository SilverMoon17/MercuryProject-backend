using FluentValidation;
using MercuryProject.Application.Idea.Commands.Approve;

namespace MercuryProject.Application.Idea.Approve
{
    public class IdeaUpdateStatusValidator : AbstractValidator<IdeaUpdateStatusCommand>
    {
        public IdeaUpdateStatusValidator()
        {
            RuleFor(i => i.Id).NotEmpty();
        }
    }
}
