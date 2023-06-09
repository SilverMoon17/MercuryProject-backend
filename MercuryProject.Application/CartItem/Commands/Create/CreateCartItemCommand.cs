using ErrorOr;
using MediatR;
using MercuryProject.Application.CartItem.Common;

namespace MercuryProject.Application.CartItem.Commands.Create
{
    public record CreateCartItemCommand
    (
        Guid ProductId,
        Guid CustomerId,
        int Quantity,
        string Name,
        string Description,
        decimal Price,
        string Category,
        string IconUrl
    ) : IRequest<ErrorOr<CartItemResult>>;
}
