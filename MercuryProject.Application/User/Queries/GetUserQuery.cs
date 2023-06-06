using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ErrorOr;
using MediatR;
using MercuryProject.Application.User.Common;

namespace MercuryProject.Application.User.Queries
{
    public record GetUserQuery() : IRequest<ErrorOr<UserResult>>;
}
