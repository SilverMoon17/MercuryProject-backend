using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ErrorOr;
using MediatR;

namespace MercuryProject.Application.ShoppingCart.Queries.GetActiveById
{
    public record GetActiveShoppingCartByUserIdQuery() : IRequest<ErrorOr<Domain.ShoppingCart.ShoppingCart>>;
}
