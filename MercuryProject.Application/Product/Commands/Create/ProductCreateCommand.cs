using ErrorOr;
using MediatR;
using MercuryProject.Application.Product.Common;

namespace MercuryProject.Application.Product.Commands.Create
{
    public record ProductCreateCommand
    (
        string Name,
        string Description,
        decimal Price,
        int Stock,
        string Category,
        string IconUrl
    ) : IRequest<ErrorOr<ProductResult>>;
}
