using MediatR;
using ErrorOr;
using MercuryProject.Application.Common.Interfaces.Persistence;
using MercuryProject.Application.Product.Common;
using MercuryProject.Domain.Common.Errors;
using System.Web;
using MercuryProject.Application.Common.Interfaces.Services;
using MercuryProject.Domain.User.ValueObjects;


namespace MercuryProject.Application.Product.Commands.Create
{
    internal class ProductCreateCommandHandler : IRequestHandler<ProductCreateCommand, ErrorOr<ProductCreateResult>>
    {
        private readonly IProductRepository _productRepository;
        private readonly IUserRepository _userRepository;

        public ProductCreateCommandHandler(IProductRepository productRepository, IUserRepository userRepository)
        {
            _productRepository = productRepository;
            _userRepository = userRepository;
        }

        public async Task<ErrorOr<ProductCreateResult>> Handle(ProductCreateCommand request, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;

            if (await _productRepository.GetProductByName(request.Name) is not null)
            {
                return Errors.Product.DuplicateProductName;
            }

            var userId = UserId.Create(Guid.Parse(_userRepository.GetUserId()));

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

            return new ProductCreateResult(product);
        }
    }
}
