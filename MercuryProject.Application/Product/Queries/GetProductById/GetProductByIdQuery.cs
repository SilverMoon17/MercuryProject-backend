using ErrorOr;
using MediatR;
using MercuryProject.Application.Product.Common;

namespace MercuryProject.Application.Product.Queries.GetProductById
{
    public record GetProductByIdQuery(string Id) : IRequest<ErrorOr<ProductResult>>;
}
