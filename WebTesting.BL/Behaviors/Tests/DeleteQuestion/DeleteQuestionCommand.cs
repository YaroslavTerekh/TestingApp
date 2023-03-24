using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebTesting.BL.Behaviors.Tests.DeleteQuestion;

public class DeleteQuestionCommand : IRequest
{
    public Guid Id { get; set; }

    public DeleteQuestionCommand(Guid id) => Id = id;
}
