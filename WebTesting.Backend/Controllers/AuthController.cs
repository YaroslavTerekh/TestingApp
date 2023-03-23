using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebTesting.BL.Behaviors.Authorization.Login;
using WebTesting.BL.Behaviors.Authorization.Register;
using WebTesting.Domain.Constants;

namespace WebTesting.Backend.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediatr;

        public AuthController(IMediator mediatr)
        {
            _mediatr = mediatr;
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterUserAsync(
            RegisterCommand command,
            CancellationToken cancellationToken = default
        )
        {
            return Ok(await _mediatr.Send(command, cancellationToken));
        }

        [HttpPost("login")]
        public async Task<IActionResult> LoginUserAsync(
            LoginCommand command,
            CancellationToken cancellationToken = default
        )
        {
            return Ok(await _mediatr.Send(command, cancellationToken));
        }
    }
}
