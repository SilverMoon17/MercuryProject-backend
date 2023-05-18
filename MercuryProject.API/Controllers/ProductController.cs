using ErrorOr;
using MapsterMapper;
using MediatR;
using MercuryProject.Application.Common.Interfaces.Persistence;
using MercuryProject.Application.Product.Commands.Create;
using MercuryProject.Application.Product.Commands.Delete;
using MercuryProject.Application.Product.Common;
using MercuryProject.Application.Product.Queries.GetProductById;
using MercuryProject.Contracts.Product;
using MercuryProject.Domain.Product;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MercuryProject.API.Controllers
{
    [Route("product")]
    public class ProductController : ApiController
    {
        private readonly IMapper _mapper;
        private readonly ISender _mediator;
        private readonly IProductRepository _productRepository;


        public ProductController(IProductRepository productRepository, IMapper mapper, ISender mediator)
        {
            _productRepository = productRepository;
            _mapper = mapper;
            _mediator = mediator;
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreateProduct(ProductCreateRequest request)
        {
            var command = _mapper.Map<ProductCreateCommand>(request);
            ErrorOr<ProductResult> result = await _mediator.Send(command);

            return result.Match(result => Ok(_mapper.Map<ProductResponse>(result)),
                errors => Problem(errors));
        }

        [HttpGet("getAllProducts")]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<Product>>> GetAllProducts()
        {
            var result = await _productRepository.GetAllProductsAsync();
            return Ok(result);
        }
        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetProductById(string id)
        {
            var query = new GetProductByIdQuery(id);
            var result = await _mediator.Send(query);
            return result.Match(result => Ok(_mapper.Map<ProductResponse>(result)),
                errors => Problem(errors));
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteProduct(string id)
        {
            var command = new ProductDeleteCommand(id);
            var result = await _mediator.Send(command);
            return result.Match(result => Ok(),
                errors => Problem(errors));
        }
    }
}
