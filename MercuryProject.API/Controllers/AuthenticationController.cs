using ErrorOr;
using MapsterMapper;
using MediatR;
using MercuryProject.Application.Authentication.Commands.Register;
using MercuryProject.Application.Authentication.Common;
using MercuryProject.Application.Authentication.Queries.Login;
using MercuryProject.Contracts.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MercuryProject.API.Controllers
{
    [Route("auth")]
    [AllowAnonymous]
    public class AuthenticationController : ApiController
    {
        private readonly IMapper _mapper;
        private readonly ISender _mediator;

        public AuthenticationController(ISender mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterRequest request)
        {
            var command = _mapper.Map<RegisterCommand>(request);
            ErrorOr<AuthenticationResult> result = await _mediator.Send(command);

            return result.Match(result => Ok(_mapper.Map<AuthenticationResponse>(result)),
                errors => Problem(errors));
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            var query = _mapper.Map<LoginQuery>(request);
            var result = await _mediator.Send(query);
            return result.Match(result => Ok(_mapper.Map<AuthenticationResponse>(result)),
                errors => Problem(errors));
        }

    }
}
