using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ErrorOr;
using MediatR;

namespace MercuryProject.Application.CartItem.Commands.Delete
{
    public record DeleteCartItemCommand(string Id) : IRequest<ErrorOr<bool>>;
}
