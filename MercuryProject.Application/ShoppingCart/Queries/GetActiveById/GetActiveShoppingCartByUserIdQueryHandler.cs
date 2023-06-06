using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using MercuryProject.Application.Common.Interfaces.Persistence;
using ErrorOr;

namespace MercuryProject.Application.ShoppingCart.Queries.GetActiveById
{
    public class GetActiveShoppingCartByUserIdQueryHandler : IRequestHandler<GetActiveShoppingCartByUserIdQuery, ErrorOr<Domain.ShoppingCart.ShoppingCart>>
    {
        private readonly IShoppingCartRepository _shoppingCartRepository;
        private readonly IUserRepository _userRepository;

        public GetActiveShoppingCartByUserIdQueryHandler(IShoppingCartRepository shoppingCartRepository, IUserRepository userRepository)
        {
            _shoppingCartRepository = shoppingCartRepository;
            _userRepository = userRepository;
        }

        public async Task<ErrorOr<Domain.ShoppingCart.ShoppingCart>> Handle(GetActiveShoppingCartByUserIdQuery request, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;
            var userId = _userRepository.GetUserId();
            var shoppingCart = await _shoppingCartRepository.GetActiveShoppingCartAsync(userId);

            return shoppingCart;
        }
    }
}
