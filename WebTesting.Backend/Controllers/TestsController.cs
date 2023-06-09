﻿using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebTesting.Backend.Extensions;
using WebTesting.BL.Behaviors.Tests.CreateQuestion;
using WebTesting.BL.Behaviors.Tests.CreateTest;
using WebTesting.BL.Behaviors.Tests.DeleteQuestion;
using WebTesting.BL.Behaviors.Tests.DeleteTest;
using WebTesting.BL.Behaviors.Tests.GetAllTests;
using WebTesting.BL.Behaviors.Tests.GetAllUsers;
using WebTesting.BL.Behaviors.Tests.GetTest;
using WebTesting.BL.Behaviors.Tests.ModifyQuestion;
using WebTesting.BL.Behaviors.Tests.ModifyTest;
using WebTesting.Domain.Constants;

namespace WebTesting.Backend.Controllers
{
    [Authorize(Policy = Policies.Admin)]
    [Route("api/test")]
    [ApiController]
    public class TestsController : BaseController
    {
        private readonly IMediator _mediatr;

        public TestsController(IMediator mediatr)
        {
            _mediatr = mediatr;
        }

        [HttpGet("all-users")]
        public async Task<IActionResult> GetAllUsersAsync(
            CancellationToken cancellationToken = default
        )
        {
            return Ok(await _mediatr.Send(new GetAllUsersQuery(), cancellationToken));
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTestsAsync(
            CancellationToken cancellationToken = default
        )
        {
            return Ok(await _mediatr.Send(new GetAllTestsQuery(CurrentUserId), cancellationToken));
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateTestAsync(
            [FromBody] CreateTestCommand command,
            CancellationToken cancellationToken = default
        )
        {
            await _mediatr.Send(command, cancellationToken);

            return Ok();
        }

        [HttpPut("modify")]
        public async Task<IActionResult> ModifyTestAsync(
            [FromBody] ModifyTestCommand command,
            CancellationToken cancellationToken = default
        )
        {
            await _mediatr.Send(command, cancellationToken);

            return Ok();
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteTestAsync(
            [FromRoute] Guid id,
            CancellationToken cancellationToken = default
        )
        {
            await _mediatr.Send(new DeleteTestCommand(id), cancellationToken);

            return Ok();
        }

        [HttpPost("create/question")]
        public async Task<IActionResult> CreateQuestionAsync(
            [FromBody] CreateQuestionCommand command,
            CancellationToken cancellationToken = default
        )
        {
            await _mediatr.Send(command, cancellationToken);

            return Ok();
        }

        [HttpPut("modify/question")]
        public async Task<IActionResult> ModifyQuestionAsync(
            [FromBody] ModifyQuestionCommand command,
            CancellationToken cancellationToken = default
        )
        {
            await _mediatr.Send(command, cancellationToken);

            return Ok();
        }

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
