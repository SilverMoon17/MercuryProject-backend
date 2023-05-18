using FluentValidation;

namespace MercuryProject.Application.Product.Commands.Delete
{
    public class ProductDeleteCommandValidator : AbstractValidator<ProductDeleteCommand>
    {
        public ProductDeleteCommandValidator()
        {
            RuleFor(p => p.Id).NotEmpty().WithMessage("Specify the id");
        }
    }
}
