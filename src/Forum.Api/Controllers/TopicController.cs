using Forum.Application.Common.Models;
using Forum.Application.Common.Services;
using Microsoft.AspNetCore.Mvc;

namespace Forum.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TopicController : ControllerBase
    {
        private readonly ITopicService _topicService;

        public TopicController(ITopicService topicService)
        {
            _topicService = topicService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<TopicDto>), statusCode: 200)]
        public async Task<ActionResult<IEnumerable<TopicDto?>>> GetAllTopics(CancellationToken cancellationToken)
        {
            return Ok(await _topicService.GetAllTopics(cancellationToken));
        }


    }
}
