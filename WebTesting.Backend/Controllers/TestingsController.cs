﻿using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebTesting.Backend.Extensions;
using WebTesting.BL.Behaviors.Tests.CompleteTest;
using WebTesting.BL.Behaviors.Tests.GetAllTests;
using WebTesting.BL.Behaviors.Tests.GetTest;
using WebTesting.Domain.Constants;

namespace WebTesting.Backend.Controllers;

[Authorize]
[Route("api/testings")]
[ApiController]
public class TestingsController : BaseController
{
    private readonly IMediator _mediatr;

    public TestingsController(IMediator mediatr)
    {
        _mediatr = mediatr;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllTestsAsync(
        CancellationToken cancellationToken = default
    )
    {
        return Ok(await _mediatr.Send(new GetAllTestsQuery(CurrentUserId), cancellationToken));
    }

    [Authorize(Policy = Policies.User)]
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetTestAsync(
        [FromRoute] Guid id,
        CancellationToken cancellationToken = default
    )
    {
        return Ok(await _mediatr.Send(new GetTestQuery(CurrentUserId, id), cancellationToken));
    }

    [Authorize(Policy = Policies.User)]
    [HttpPost("complete")]
    public async Task<IActionResult> CompleteTestAsync(
        [FromBody] CompleteTestCommand command,
        CancellationToken cancellationToken = default
    )
    {
        command.CurrentUserId = CurrentUserId;

        return Ok(await _mediatr.Send(command, cancellationToken));
    }
}
