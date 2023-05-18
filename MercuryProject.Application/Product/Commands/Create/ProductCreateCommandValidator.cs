using FluentValidation;

namespace MercuryProject.Application.Product.Commands.Create
{
    public class ProductCreateCommandValidator : AbstractValidator<ProductCreateCommand>
    {
        public ProductCreateCommandValidator()
        {
            RuleFor(p => p.Name).NotEmpty();
            RuleFor(p => p.Description).NotEmpty();
            RuleFor(p => p.Price).NotEmpty().GreaterThanOrEqualTo(1);
            RuleFor(p => p.Stock).NotEmpty().GreaterThan(0);
            RuleFor(p => p.Category).NotEmpty();
        }
    }
}
