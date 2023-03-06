using Microsoft.AspNetCore.Mvc;

namespace MercuryProject.API.Controllers
{
    [Route("[controller]")]
    public class ProductController : ApiController
    {
        [HttpGet("listProducts")]
        public IActionResult ListProducts()
        {
            return Ok(Array.Empty<string>());
        }
    }
}
