using ErrorOr;
using MediatR;

namespace MercuryProject.Application.Product.Commands.Delete
{
    public record ProductDeleteCommand(string Id) : IRequest<ErrorOr<bool>>;
}
