using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebTesting.BL.Behaviors.Tests.ModifyTest;

public class ModifyTestCommand : IRequest
{
    public Guid Id { get; set; }

    public string Title { get; set; }

    public string Description { get; set; }

    public List<Guid> UserIds { get; set; } = new();
}
