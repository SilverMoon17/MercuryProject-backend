using ErrorOr;
using MapsterMapper;
using MediatR;
using MercuryProject.Application.Authentication.Commands.Register;
using MercuryProject.Application.Authentication.Queries.Login;
using MercuryProject.Application.Product.Commands.Create;
using MercuryProject.Application.Product.Common;
using MercuryProject.Contracts.Authentication;
using MercuryProject.Contracts.Product;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MercuryProject.API.Controllers
{
    [Route("product")]
    [Authorize(Roles = "User")]
    public class ProductController : ApiController
    {
        private readonly IMapper _mapper;
        private readonly ISender _mediator;


        public ProductController(IMapper mapper, ISender sender)
        {
            _mapper = mapper;
            _mediator = sender;
        }
    }
}
