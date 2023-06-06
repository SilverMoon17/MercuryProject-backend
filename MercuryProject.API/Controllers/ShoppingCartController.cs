using ErrorOr;
using MapsterMapper;
using MediatR;
using MercuryProject.Application.ShoppingCart.Queries.GetActiveById;
using MercuryProject.Domain.ShoppingCart.Dto;
using Microsoft.AspNetCore.Mvc;



namespace MercuryProject.API.Controllers
{
    [Route("shoppingCart")]
    public class ShoppingCartController : ApiController
    {
        private readonly IMapper _mapper;
        private readonly ISender _mediator;
        public ShoppingCartController(IMapper mapper, ISender mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        [HttpGet]
        [Route("active")]
        public async Task<IActionResult> GetActiveShoppingCartByUserId()
        {
            var query = new GetActiveShoppingCartByUserIdQuery();
            var result = await _mediator.Send(query);
            var mappedResult = _mapper.Map<ShoppingCartDto>(result.Value);

            return result.Match(result => Ok(_mapper.Map<ShoppingCartDto>(result)),
                errors => Problem(errors));
        }
    }
}
