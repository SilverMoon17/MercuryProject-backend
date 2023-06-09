using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ErrorOr;
using MediatR;
using MercuryProject.Application.Common.Interfaces.Persistence;
using MercuryProject.Domain.CartItem.ValueObjects;
using MercuryProject.Domain.Common.Errors;

namespace MercuryProject.Application.CartItem.Commands.Delete
{
    internal class DeleteCartItemCommandHandler : IRequestHandler<DeleteCartItemCommand, ErrorOr<bool>>
    {
        private readonly ICartItemRepository _cartItemRepository;

        public DeleteCartItemCommandHandler(ICartItemRepository cartItemRepository)
        {
            _cartItemRepository = cartItemRepository;
        }

        public async Task<ErrorOr<bool>> Handle(DeleteCartItemCommand request, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;

            if (Guid.TryParse(request.Id, out var cartItemId))
            {
                Domain.CartItem.CartItem cartItem = await _cartItemRepository.GetCartItemById(CartItemId.Create(cartItemId));

                if (cartItem is null)
                {
                    return Errors.CartItem.NotFound;
                }

                await _cartItemRepository.RemoveAsync(cartItem);
                return true;

            }

            return Errors.CartItem.CorrectId;
        }
    }
}
