using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ErrorOr;
using MediatR;
using MercuryProject.Application.Authentication.Common;
using MercuryProject.Application.Common.Interfaces.Authentication;
using MercuryProject.Application.Common.Interfaces.Persistence;
using MercuryProject.Domain.Common.Errors;
using MercuryProject.Domain.User;

namespace MercuryProject.Application.Authentication.Commands.Register
{
    public class RegisterCommandHandler : IRequestHandler<RegisterCommand ,ErrorOr<AuthenticationResult>>
    {
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly IUserRepository _userRepository;

        public RegisterCommandHandler(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
            _userRepository = userRepository;
        }

        public async Task<ErrorOr<AuthenticationResult>> Handle(RegisterCommand command, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;
            if (command.Password != command.ConfirmedPassword)
            {
                return Errors.User.PasswordConfirmation;
            }
            // 1. Check if user already exists
            if (_userRepository.GetUserByEmail(command.Email) is not null)
            {
                return Errors.User.DuplicateEmail;
            }

            if (_userRepository.GetUserByUsername(command.Username) is not null)
            {
                return Errors.User.DuplicateUsername;
            }

            // Create user (generate unique ID)
            var user = User.Create(command.Username,
                command.FirstName,
                command.LastName,
                command.Email, 
                command.Password, 
                command.ConfirmedPassword);

            _userRepository.Add(user);


            // Create JWT Token
            var token = _jwtTokenGenerator.GenerateToken(user);
            return new AuthenticationResult(user, token);
        }
    }
}
