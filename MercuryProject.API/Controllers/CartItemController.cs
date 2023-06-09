using ErrorOr;
using MapsterMapper;
using MediatR;
using MercuryProject.Application.CartItem.Commands.Create;
using MercuryProject.Application.CartItem.Commands.Delete;
using MercuryProject.Application.CartItem.Common;
using MercuryProject.Contracts.CartItem;
using Microsoft.AspNetCore.Mvc;

namespace MercuryProject.API.Controllers
{
    [Route("cartItem")]
    public class CartItemController : ApiController
    {
        private readonly IMapper _mapper;
        private readonly ISender _mediator;

        public CartItemController(IMapper mapper, ISender mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> AddCartItem(CartItemCreateRequest request)
        {
            var command = _mapper.Map<CreateCartItemCommand>(request);
            ErrorOr<CartItemResult> result = await _mediator.Send(command);

            return result.Match(result => Ok(_mapper.Map<CartItemResponse>(result)),
                errors => Problem(errors));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCartItem(string id)
        {
            var command = new DeleteCartItemCommand(id);
            var result = await _mediator.Send(command);

            return result.Match(result => Ok(result),
                errors => Problem(errors));
        }
    }
}
