using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebTesting.Domain.DataTransferObjects;

namespace WebTesting.BL.Behaviors.Tests.ModifyQuestion;

public class ModifyQuestionCommand : IRequest
{
    public Guid Id { get; set; }

    public string Text { get; set; }

    public List<OptionDTO> Options { get; set; } = new();
}
