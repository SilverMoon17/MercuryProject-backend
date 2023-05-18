using ErrorOr;
using MediatR;
using MercuryProject.Application.Common.Interfaces.Persistence;
using MercuryProject.Application.Product.Common;
using MercuryProject.Domain.Common.Errors;

namespace MercuryProject.Application.Product.Queries.GetProductById
{
    public class GetProductByIdHandler : IRequestHandler<GetProductByIdQuery, ErrorOr<ProductResult>>
    {
        private readonly IProductRepository _productRepository;

        public GetProductByIdHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<ErrorOr<ProductResult>> Handle(GetProductByIdQuery query, CancellationToken cancellationToken)
        {
            if (Guid.TryParse(query.Id, out var productGuid))
            {
                var product = await _productRepository.GetProductById(productGuid);

                if (product is null)
                {
                    return Errors.Product.ProductNotFound;
                }

                return new ProductResult(product);
            }

            return Errors.Product.CorrectId;
        }
    }
}
