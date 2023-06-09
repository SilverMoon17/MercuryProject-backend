using MercuryProject.Domain.User;

namespace MercuryProject.Application.Authentication.Common
{
    public record AuthenticationResult
    (
        Domain.User.User User,
        string Token
    );
}
