using FluentValidation;

namespace MercuryProject.Application.Product.Queries.GetProductById
{
    public class GetProductByIdValidator : AbstractValidator<GetProductByIdQuery>
    {
        public GetProductByIdValidator()
        {
            RuleFor(p => p.Id).NotEmpty().WithMessage("Specify the id!");
        }
    }
}
