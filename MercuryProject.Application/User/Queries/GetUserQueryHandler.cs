using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ErrorOr;
using MediatR;
using MercuryProject.Application.Common.Interfaces.Persistence;
using MercuryProject.Application.Idea.Common;
using MercuryProject.Application.User.Common;
using MercuryProject.Domain.Common.Errors;
using MercuryProject.Domain.User.ValueObjects;

namespace MercuryProject.Application.User.Queries
{
    public class GetUserQueryHandler : IRequestHandler<GetUserQuery, ErrorOr<UserResult>>
    {
        private readonly IUserRepository _userRepository;

        public GetUserQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<ErrorOr<UserResult>> Handle(GetUserQuery query, CancellationToken cancellationToken)
        {
            var userId = _userRepository.GetUserId();
            var user = await _userRepository.GetUserById(userId);

            if (user is null)
            {
                return Errors.User.UserNotFoundError;
            }

            return new UserResult(user);
        }
    }
}
