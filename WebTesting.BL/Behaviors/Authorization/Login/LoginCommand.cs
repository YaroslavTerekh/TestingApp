using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebTesting.Domain.DataTransferObjects;

namespace WebTesting.BL.Behaviors.Authorization.Login
{
    public class LoginCommand : IRequest<TokenDTO>
    {
        public string Email { get; set; }

        public string Password { get; set; }
    }
}
