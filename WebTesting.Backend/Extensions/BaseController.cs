using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace WebTesting.Backend.Extensions
{
    public class BaseController : ControllerBase
    {
        public Guid CurrentUserId => Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
    }
}
