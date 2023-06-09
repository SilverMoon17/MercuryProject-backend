using ErrorOr;
using MediatR;
using MercuryProject.Application.Authentication.Common;
using MercuryProject.Application.Common.Interfaces.Authentication;
using MercuryProject.Application.Common.Interfaces.Persistence;
using MercuryProject.Application.Common.Interfaces.Services;
using MercuryProject.Domain.Common.Errors;

namespace MercuryProject.Application.Authentication.Queries.Login
{
    internal class LoginQueryHandler : IRequestHandler<LoginQuery, ErrorOr<AuthenticationResult>>
    {
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher _passwordHasher;

        public LoginQueryHandler(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository, IPasswordHasher passwordHasher)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
        }

        public async Task<ErrorOr<AuthenticationResult>> Handle(LoginQuery query, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUserByEmail(query.Email)!;

            if (user is null)
            {
                return Errors.Authentication.InvalidCredentials;
            }

            // 2. Validate the password is correct
            if (user.Password != _passwordHasher.Hash(query.Password))
            {
                return Errors.Authentication.InvalidCredentials;
            }

            // 3. Create JWT token
            var token = _jwtTokenGenerator.GenerateToken(user);
            return new AuthenticationResult(user, token);

        }
    }
}
