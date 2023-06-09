using FluentValidation;

namespace MercuryProject.Application.Authentication.Commands.Register
{
    public class RegisterCommandValidator : AbstractValidator<RegisterCommand>
    {
        public RegisterCommandValidator()
        {
            RuleFor(x => x.Username).MinimumLength(5).WithMessage("Username must be minimal 5 symbols").MaximumLength(30).WithMessage("Username is too long").NotEmpty().WithMessage("Username field is required");
            RuleFor(x => x.Email).EmailAddress().WithMessage("Invalid email address").NotEmpty().WithMessage("Email address is required");
            RuleFor(x => x.FirstName).NotEmpty().WithMessage("First name field is required");
            RuleFor(x => x.LastName).NotEmpty().WithMessage("Last name field is required");
            RuleFor(x => x.Password).MinimumLength(8).WithMessage("Too short (8-30 symbols)").MaximumLength(30).WithMessage("'Too long (8-30 symbols)'").NotEmpty().WithMessage("Password field is required");
        }
    }
}
