namespace WebTesting.Domain.Entities;

public class Option : BaseEntity
{
    public string Answer { get; set; }

    public bool IsRight { get; set; }

    public Guid QuestionId { get; set; }

    public Question Question { get; set; }
}
