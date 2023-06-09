using FluentValidation;

namespace MercuryProject.Application.CartItem.Commands.Create
{
    public class CreateCartItemCommandValidator : AbstractValidator<CreateCartItemCommand>
    {
        public CreateCartItemCommandValidator()
        {
            RuleFor(ci => ci.ProductId).NotEmpty();
            RuleFor(ci => ci.Quantity).NotEmpty();
        }
    }
}
