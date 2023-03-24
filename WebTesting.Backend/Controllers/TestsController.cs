using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebTesting.Backend.Extensions;
using WebTesting.BL.Behaviors.Tests.CreateQuestion;
using WebTesting.BL.Behaviors.Tests.CreateTest;
using WebTesting.BL.Behaviors.Tests.DeleteQuestion;
using WebTesting.BL.Behaviors.Tests.DeleteTest;
using WebTesting.BL.Behaviors.Tests.GetTest;
using WebTesting.BL.Behaviors.Tests.ModifyQuestion;
using WebTesting.BL.Behaviors.Tests.ModifyTest;
using WebTesting.Domain.Constants;

namespace WebTesting.Backend.Controllers
{
    [Authorize]
    [Route("api/test")]
    [ApiController]
    public class TestsController : BaseController
    {
        private readonly IMediator _mediatr;

        public TestsController(IMediator mediatr)
        {
            _mediatr = mediatr;
        }

        [HttpPost("get/{id:guid}")]
        public async Task<IActionResult> GetTestAsync(
            [FromRoute] Guid id,
            CancellationToken cancellationToken = default
        )
        {
            return Ok(await _mediatr.Send(new GetTestQuery(CurrentUserId, id), cancellationToken));
        }

        [Authorize(Policy = Policies.Admin)]
        [HttpPost("create")]
        public async Task<IActionResult> CreateTestAsync(
            [FromBody] CreateTestCommand command,
            CancellationToken cancellationToken = default
        )
        {
            await _mediatr.Send(command, cancellationToken);

            return Ok();
        }

        [Authorize(Policy = Policies.Admin)]
        [HttpPut("modify")]
        public async Task<IActionResult> ModifyTestAsync(
            [FromBody] ModifyTestCommand command,
            CancellationToken cancellationToken = default
        )
        {
            await _mediatr.Send(command, cancellationToken);

            return Ok();
        }

        [Authorize(Policy = Policies.Admin)]
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteTestAsync(
            [FromRoute] Guid id,
            CancellationToken cancellationToken = default
        )
        {
            await _mediatr.Send(new DeleteTestCommand(id), cancellationToken);

            return Ok();
        }

        [Authorize(Policy = Policies.Admin)]
        [HttpPost("create/question")]
        public async Task<IActionResult> CreateQuestionAsync(
            [FromBody] CreateQuestionCommand command,
            CancellationToken cancellationToken = default
        )
        {
            await _mediatr.Send(command, cancellationToken);

            return Ok();
        }

        [Authorize(Policy = Policies.Admin)]
        [HttpPut("modify/question")]
        public async Task<IActionResult> ModifyQuestionAsync(
            [FromBody] ModifyQuestionCommand command,
            CancellationToken cancellationToken = default 
        )
        {
            await _mediatr.Send(command, cancellationToken);

            return Ok();
        }

        [Authorize(Policy = Policies.Admin)]
        [HttpDelete("question/{id:guid}")]
        public async Task<IActionResult> DeleteQuestionAsync(
            [FromRoute] Guid id,
            CancellationToken cancellationToken = default
        )
        {
            await _mediatr.Send(new DeleteQuestionCommand(id), cancellationToken);

            return Ok();
        }
    }
}
