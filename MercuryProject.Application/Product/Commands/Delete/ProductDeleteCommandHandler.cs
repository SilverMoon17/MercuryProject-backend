using ErrorOr;
using MediatR;
using MercuryProject.Application.Common.Interfaces.Persistence;
using MercuryProject.Domain.Common.Errors;

namespace MercuryProject.Application.Product.Commands.Delete
{
    public class ProductDeleteCommandHandler : IRequestHandler<ProductDeleteCommand, ErrorOr<bool>>
    {
        private readonly IProductRepository _productRepository;

        public ProductDeleteCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<ErrorOr<bool>> Handle(ProductDeleteCommand request, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;

            if (Guid.TryParse(request.Id, out var productGuid))
            {
                Domain.Product.Product? product = await _productRepository.GetProductById(productGuid);

                if (product is null)
                {
                    return Errors.Product.ProductNotFound;
                }

                bool status = await _productRepository.DeleteProduct(product);

                return status;
            }

            return Errors.Product.CorrectId;


        }
    }
}
