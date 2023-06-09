using ErrorOr;
using MediatR;
using MercuryProject.Application.Product.Common;
using Microsoft.AspNetCore.Http;

namespace MercuryProject.Application.Product.Commands.Create
{
    public record ProductCreateCommand
    (
        string Name,
        string Description,
        decimal Price,
        int Stock,
        string Category,
        // string IconUrl,
        List<IFormFile>? Files
    ) : IRequest<ErrorOr<ProductResult>>;
}
