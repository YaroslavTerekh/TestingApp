using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebTesting.BL.DbConnection;
using WebTesting.Domain.DataTransferObjects;

namespace WebTesting.BL.Behaviors.Tests.CompleteTest;

public class CompleteTestHandler : IRequestHandler<CompleteTestCommand, ResultDTO>
{
    private readonly DataContext _context;

    public CompleteTestHandler(DataContext context)
    {
        _context = context;
    }

    public async Task<ResultDTO> Handle(CompleteTestCommand request, CancellationToken cancellationToken)
    {
        var test = await _context.Tests
            .Include(t => t.Users)
            .Include(t => t.Questions)
                .ThenInclude(t => t.Options)
            .FirstOrDefaultAsync(t => t.Id == request.Id, cancellationToken);

        if (test is null)
        {
            throw new Exception("Test not found");
        }

        if(!test.Users.Select(t => t.Id).Contains(request.CurrentUserId))
        {
            throw new Exception("You can pass only your own tests");
        }   

        var totalQuestions = test.Questions.Count();
        var totalRequestQuestions = test.Questions.Select(t => t.Id).Intersect(request.CheckAnswers.Select(t => t.QuestionId)).Count();

        if (totalRequestQuestions != totalQuestions)
        {
            throw new Exception("Wrong answer ids found");
        }

        var point = 0;
        
        foreach(var answer in request.CheckAnswers)
        {
            var testQuestion = test.Questions.FirstOrDefault(t => t.Id == answer.QuestionId);

            if(testQuestion.Options.Where(t => t.IsRight == true).Select(t => t.Id).Contains(answer.OptionId))
            {
                point++;
            }
        }

        return new ResultDTO
        {
            Id = test.Id,
            TestTitle = test.Title,
            TotalQuestions = totalQuestions,
            Point = point
        };
    }
}
