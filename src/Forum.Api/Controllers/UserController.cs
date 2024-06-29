using Forum.Application.Common.Models;
using Forum.Application.Common.Services;
using Microsoft.AspNetCore.Mvc;

namespace Forum.Api.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<UserDto>), statusCode: 200)]
        public async Task<ActionResult<IEnumerable<UserDto?>>> GetAllUsers(CancellationToken cancellationToken)
        {
            return Ok(await _userService.GetAllUsers(cancellationToken));
        }

    }
}
