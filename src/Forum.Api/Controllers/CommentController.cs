using Forum.Application.Common.Models;
using Forum.Application.Common.Services;
using Microsoft.AspNetCore.Mvc;

namespace Forum.Api.Controllers
{


    [ApiController]
    [Route("api/[controller]")]
    public class CommentController : ControllerBase
    {
        private readonly ICommentService _commentService;

        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        [HttpGet("topic/{topicId}")]
        [ProducesResponseType(typeof(List<CommentDto>), statusCode: 200)]
        public async Task<ActionResult<IEnumerable<CommentDto?>>> GetCommentsByTopicId(int topicId, CancellationToken cancellationToken)
        {
            return Ok(await _commentService.GetCommentsByTopicId(topicId, cancellationToken));
        }


    }


}
