using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using ErrorOr;
using MercuryProject.Application.Authentication.Common;

namespace MercuryProject.Application.Authentication.Commands.Register
{
    public record RegisterCommand(
        string Username,
        string FirstName,
        string LastName,
        string Email,
        string Password,
        string ConfirmedPassword) :IRequest<ErrorOr<AuthenticationResult>>;
}
