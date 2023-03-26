using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebTesting.BL.Behaviors.Tests.DeleteTest;

public class DeleteTestCommand : IRequest
{
    public Guid Id { get; set; }

    public DeleteTestCommand(Guid id) => Id = id;
}
