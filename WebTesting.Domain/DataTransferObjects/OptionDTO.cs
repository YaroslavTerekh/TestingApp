namespace WebTesting.Domain.DataTransferObjects;

public class OptionDTO
{
    public Guid Id { get; set; }

    public string Answer { get; set; }

    public bool IsRight { get; set; }

    public Guid QuestionId { get; set; }
}
