using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WebTesting.BL.DbConnection;
using WebTesting.Domain.Entities;

namespace WebTesting.BL.Behaviors.Tests.CreateQuestion;

public class CreateQuestionHandler : IRequestHandler<CreateQuestionCommand>
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;

    public CreateQuestionHandler(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task Handle(CreateQuestionCommand request, CancellationToken cancellationToken)
    {
        var test = await _context.Tests
            .Include(t => t.Questions)
            .FirstOrDefaultAsync(t => t.Id == request.TestId, cancellationToken);

        var question = new Question
        {
            QuestionDescription = request.Text,
            TestId = test.Id
        };

        List<Option> mappedOptions = new List<Option>();

        foreach (var option in request.Options)
        {
            var mappedOption = _mapper.Map<Option>(option);
            mappedOption.Id = Guid.NewGuid();
            mappedOption.QuestionId = question.Id;

            mappedOptions.Add(mappedOption);
        }

        question.Options = mappedOptions;

        if (test is null)
        {
            throw new Exception("Test not found");
        }

        await _context.Questions.AddAsync(question);
        await _context.SaveChangesAsync(cancellationToken);
    }
}
