using MediatR;
using WebTesting.Domain.DataTransferObjects;
using WebTesting.Domain.Entities;

namespace WebTesting.BL.Behaviors.Tests.CreateQuestion;

public class CreateQuestionCommand : IRequest
{
    public Guid TestId { get; set; }

    public string Text { get; set; }

    public List<OptionDTO> Options { get; set; } = new();
}
