namespace WebTesting.Domain.DataTransferObjects;

public class QuestionDTO
{
    public Guid Id { get; set; }

    public Guid TestId { get; set; }

    public List<OptionDTO> Options { get; set; } = new();
}
