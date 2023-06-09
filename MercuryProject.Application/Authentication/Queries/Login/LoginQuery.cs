using ErrorOr;
using MediatR;
using MercuryProject.Application.Authentication.Common;

namespace MercuryProject.Application.Authentication.Queries.Login
{
    public record LoginQuery(
        string Email,
        string Password) : IRequest<ErrorOr<AuthenticationResult>>;
}
