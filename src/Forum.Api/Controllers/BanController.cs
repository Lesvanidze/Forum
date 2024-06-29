using Forum.Application.Common.Models;
using Forum.Application.Common.Services;
using Microsoft.AspNetCore.Mvc;

namespace Forum.Api.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class BanController : ControllerBase
    {
        private readonly IBanService _banService;

        public BanController(IBanService banService)
        {
            _banService = banService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<BanDto>), statusCode: 200)]
        public async Task<ActionResult<IEnumerable<BanDto?>>> GetBans(CancellationToken cancellationToken)
        {
            return Ok(await _banService.GetBans(cancellationToken));
        }

    }
}
