namespace WebTesting.Domain.DataTransferObjects;

public class QuestionDTO
{
    public Guid Id { get; set; }

    public Guid TestId { get; set; }

    public string QuestionDescription { get; set; }

    public List<OptionDTO> Options { get; set; } = new();
}
