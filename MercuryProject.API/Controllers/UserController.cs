using MapsterMapper;
using MediatR;
using MercuryProject.Application.Idea.Queries.GetIdeaById;
using MercuryProject.Application.User.Commands;
using MercuryProject.Application.User.Queries;
using MercuryProject.Contracts.User;
using MercuryProject.Domain.User.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MercuryProject.API.Controllers
{
    [Route("user")]
    public class UserController : ApiController
    {
        private readonly IMapper _mapper;
        private readonly ISender _mediator;

        public UserController(IMapper mapper, ISender mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserInfo()
        {
            var query = new GetUserQuery();
            var result = await _mediator.Send(query);
            return result.Match(result => Ok(_mapper.Map<UserDto>(result)),
                errors => Problem(errors));
        }
        [HttpPut]
        public async Task<IActionResult> UpdateUserInfo(UpdateUserInfoRequest request)
        {
            var query = _mapper.Map<UpdateUserInfoCommand>(request);
            await _mediator.Send(query);
            return Ok();
        }
    }
}
