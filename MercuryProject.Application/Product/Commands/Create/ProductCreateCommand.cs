using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using MercuryProject.Contracts.Product;
using ErrorOr;
using MercuryProject.Application.Product.Common;

namespace MercuryProject.Application.Product.Commands.Create
{
    public record ProductCreateCommand
    (
        string Name,
        string Description,
        double Price,
        int Stock,
        string Category,
        string IconUrl
    ) : IRequest<ErrorOr<ProductCreateResult>>;
}
