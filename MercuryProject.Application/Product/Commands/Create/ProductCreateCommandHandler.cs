using ErrorOr;
using MediatR;
using MercuryProject.Application.Common.Interfaces.Persistence;
using MercuryProject.Application.Product.Common;
using MercuryProject.Domain.Common.Errors;


namespace MercuryProject.Application.Product.Commands.Create
{
    internal class ProductCreateCommandHandler : IRequestHandler<ProductCreateCommand, ErrorOr<ProductResult>>
    {
        private readonly IProductRepository _productRepository;
        private readonly IUserRepository _userRepository;

        public ProductCreateCommandHandler(IProductRepository productRepository, IUserRepository userRepository)
        {
            _productRepository = productRepository;
            _userRepository = userRepository;
        }

        public async Task<ErrorOr<ProductResult>> Handle(ProductCreateCommand request, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;

            if (await _productRepository.GetProductByName(request.Name) is not null)
            {
                return Errors.Product.DuplicateProductName;
            }

            var userId = _userRepository.GetUserId();

            var product = Domain.Product.Product.Create(
                userId,
                request.Name,
                request.Description,
                request.Price,
                request.Stock,
                request.Category,
                request.IconUrl
                );

            _productRepository.Add(product);

            return new ProductResult(product);
        }
    }
}
