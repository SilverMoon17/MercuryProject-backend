using ErrorOr;
using MediatR;
using MercuryProject.Application.CartItem.Common;
using MercuryProject.Application.Common.Interfaces.Persistence;
using MercuryProject.Domain.Common.Errors;

namespace MercuryProject.Application.CartItem.Commands.Create
{
    public class CreateCartItemCommandHandler : IRequestHandler<CreateCartItemCommand, ErrorOr<CartItemResult>>
    {
        private readonly ICartItemRepository _cartItemRepository;
        private readonly IProductRepository _productRepository;
        private readonly IUserRepository _userRepository;
        private readonly IShoppingCartRepository _shoppingCartRepository;

        public CreateCartItemCommandHandler(ICartItemRepository cartItemRepository, IProductRepository productRepository, IUserRepository userRepository, IShoppingCartRepository shoppingCartRepository)
        {
            _cartItemRepository = cartItemRepository;
            _productRepository = productRepository;
            _userRepository = userRepository;
            _shoppingCartRepository = shoppingCartRepository;
        }

        public async Task<ErrorOr<CartItemResult>> Handle(CreateCartItemCommand request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetProductById(request.ProductId);
            if (request.Quantity > product.Stock)
            {
                return Errors.CartItem.Stock;
            }
            var userIdDb = _userRepository.GetUserId();
            var price = request.Quantity * product.Price;
            var shoppingCartDb = await _shoppingCartRepository.GetActiveShoppingCartAsync(userIdDb, price);
            var cartItemFromDb = shoppingCartDb.CartItems.FirstOrDefault(ci => ci.ProductId == product.Id);
            if (cartItemFromDb != null)
            {
                cartItemFromDb.Quantity += request.Quantity;
                cartItemFromDb.Price = cartItemFromDb.Quantity * product.Price;
                await _cartItemRepository.UpdateAsync(cartItemFromDb);
            }
            else
            {

                var cartItem = Domain.CartItem.CartItem.Create
                (
                    request.Quantity,
                    price,
                    shoppingCartDb.Id,
                    product.Id
                );

                _cartItemRepository.AddAsync(cartItem);

                cartItemFromDb = cartItem;
            }
            // элемент не найден
            return new CartItemResult(cartItemFromDb);

        }
    }
}
