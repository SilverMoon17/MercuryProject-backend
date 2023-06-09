using ErrorOr;
using MapsterMapper;
using MediatR;
using MercuryProject.Application.Common.Interfaces.Persistence;
using MercuryProject.Application.Idea.Commands.Approve;
using MercuryProject.Application.Idea.Commands.Delete;
using MercuryProject.Application.Idea.Commands.Donate;
using MercuryProject.Application.Idea.Common;
using MercuryProject.Application.Idea.Create;
using MercuryProject.Application.Idea.Queries.GetAllIdeas;
using MercuryProject.Application.Idea.Queries.GetIdeaById;
using MercuryProject.Contracts.Idea;
using MercuryProject.Domain.Enums;
using MercuryProject.Domain.Idea;
using MercuryProject.Domain.Idea.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MercuryProject.API.Controllers
{
    [Route("idea")]
    public class IdeaController : ApiController
    {
        private readonly IMapper _mapper;
        private readonly ISender _mediator;
        private readonly IIdeaRepository _ideaRepository;

        public IdeaController(IMapper mapper, ISender mediator, IIdeaRepository ideaRepository)
        {
            _mapper = mapper;
            _mediator = mediator;
            _ideaRepository = ideaRepository;
        }

        [HttpPost]
        public async Task<IActionResult> CreateIdea([FromForm] IdeaCreateRequest request)
        {
            //var command = _mapper.Map<IdeaCreateCommand>(request);
            var command = new IdeaCreateCommand(
                request.Title,
                request.Description,
                request.Goal,
                request.Category,
                request.Files
            );
            ErrorOr<IdeaResult> result = await _mediator.Send(command);

            return result.Match(result => Ok(_mapper.Map<IdeaResponse>(result)),
                errors => Problem(errors));
        }
        [HttpGet("getAllIdeas")]
        [AllowAnonymous]
        public async Task<IActionResult> GetAllIdeas()
        {
            var ideas = await _ideaRepository.GetAllIdeasAsync();
            var result = _mapper.Map<IEnumerable<IdeaDto>>(ideas);
            return Ok(result);
        }
        [HttpGet("allApproved")]
        [AllowAnonymous]
        public async Task<IActionResult> GetAllApprovedIdeas()
        {
            var query = new GetAllIdeasQuery(i => i.Status == IdeaStatus.Approved);
            var result = await _mediator.Send(query);

            return Ok(_mapper.Map<IEnumerable<IdeaDto>>(result));
        }
        [HttpGet("allReview")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAllReviewIdeas()
        {
            var query = new GetAllIdeasQuery(i => i.Status == IdeaStatus.Review);
            var result = await _mediator.Send(query);

            return Ok(_mapper.Map<IEnumerable<IdeaDto>>(result));
        }
        [HttpGet("allProjects")]
        public async Task<IActionResult> GetAllReviewProjects()
        {
            var query = new GetAllIdeasQuery(i => i.Status == IdeaStatus.Project);
            var result = await _mediator.Send(query);

            return Ok(_mapper.Map<IEnumerable<IdeaDto>>(result));
        }
        [HttpPut("approve/{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> ApproveIdea(string id)
        {
            var command = new IdeaUpdateStatusCommand(id, IdeaStatus.Approved);
            ErrorOr<Idea> result = await _mediator.Send(command);

            return result.Match(result => Ok(_mapper.Map<IdeaDto>(result)),
                errors => Problem(errors));
        }
        [HttpPut("donate")]
        public async Task<IActionResult> Donate(IdeaDonateRequest request)
        {
            var command = _mapper.Map<DonateIdeaCommand>(request);
            var result = await _mediator.Send(command);

            return result.Match(result => Ok(_mapper.Map<IdeaDto>(result)),
                errors => Problem(errors));
        }
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteIdea(string id)
        {
            var command = new IdeaDeleteCommand(id);
            var result = await _mediator.Send(command);
            return result.Match(result => Ok("Deleted"),
                errors => Problem(errors));
        }
        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetIdeaById(string id)
        {
            var query = new GetIdeaByIdQuery(id);
            var result = await _mediator.Send(query);
            return result.Match(result => Ok(_mapper.Map<IdeaResponse>(result)),
                errors => Problem(errors));
        }
    }
}
