using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebTesting.BL.Behaviors.Authorization.Register;
using WebTesting.Domain.DataTransferObjects;
using WebTesting.Domain.Entities;

namespace WebTesting.BL.Services.Abstractions
{
    public interface IJWTService
    {
        public TokenDTO GenerateToken(User user, CancellationToken cancellationToken);
    }
}
