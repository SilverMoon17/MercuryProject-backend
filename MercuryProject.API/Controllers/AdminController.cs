using ErrorOr;
using MercuryProject.Application.Authentication.Commands.Register;
using MercuryProject.Application.Common.Interfaces.Persistence;
using MercuryProject.Contracts.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MercuryProject.API.Controllers
{
    [Route("admin")]
    [Authorize(Roles = "Developer,Admin")]
    public class AdminController : ApiController
    {
        private readonly IUserRepository _userRepository;

        public AdminController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpPatch]
        [Route("add")]
        public async Task<IActionResult> AddAdmin(string username)
        {
            ErrorOr<bool> result= await _userRepository.AddAdminByUsername(username);

            return result.Match(result => Ok(),
                errors => Problem(errors));
        }


    }
}
