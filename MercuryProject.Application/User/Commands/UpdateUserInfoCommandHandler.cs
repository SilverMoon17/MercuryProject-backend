using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using MercuryProject.Application.Common.Interfaces.Persistence;

namespace MercuryProject.Application.User.Commands
{
    public class UpdateUserInfoCommandHandler : IRequestHandler<UpdateUserInfoCommand>
    {
        private readonly IUserRepository _userRepository;

        public UpdateUserInfoCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task Handle(UpdateUserInfoCommand request, CancellationToken cancellationToken)
        {
            var userIdDb = _userRepository.GetUserId();
            var userDb = await _userRepository.GetUserById(userIdDb);
            userDb.Username = request.Username;
            userDb.Fullname = request.Fullname;
            userDb.Email = request.Email;
            userDb.Mobile = request.Mobile;
            await _userRepository.UpdateUser(userDb);
        }
    }
}
