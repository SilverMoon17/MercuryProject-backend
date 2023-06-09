using ErrorOr;
using MediatR;
using MercuryProject.Application.Authentication.Common;
using MercuryProject.Application.Common.Interfaces.Authentication;
using MercuryProject.Application.Common.Interfaces.Persistence;
using MercuryProject.Application.Common.Interfaces.Services;
using MercuryProject.Domain.Common.Errors;
using MercuryProject.Domain.User;

namespace MercuryProject.Application.Authentication.Commands.Register
{
    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, ErrorOr<AuthenticationResult>>
    {
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher _passwordHasher;

        public RegisterCommandHandler(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository, IPasswordHasher passwordHasher)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
        }

        public async Task<ErrorOr<AuthenticationResult>> Handle(RegisterCommand command, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;
            var userCheckByEmail = await _userRepository.GetUserByEmail(command.Email)!;
            var userCheckByUsername = await _userRepository.GetUserByUsername(command.Username)!;
            if (command.Password != command.ConfirmedPassword)
            {
                return Errors.User.PasswordConfirmation;
            }
            // 1. Check if user already exists
            if (userCheckByEmail is not null)
            {
                return Errors.User.DuplicateEmail;
            }

            if (userCheckByUsername is not null)
            {
                return Errors.User.DuplicateUsername;
            }

            // Create user (generate unique ID)
            var user = Domain.User.User.Create(command.Username,
                command.FirstName,
                command.LastName,
                command.Email,
                _passwordHasher.Hash(command.Password),
                _passwordHasher.Hash(command.ConfirmedPassword));

            _userRepository.Add(user);


            // Create JWT Token
            var token = _jwtTokenGenerator.GenerateToken(user);
            return new AuthenticationResult(user, token);
        }
    }
}
