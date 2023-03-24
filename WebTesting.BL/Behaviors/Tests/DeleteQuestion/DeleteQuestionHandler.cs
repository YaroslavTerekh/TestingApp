using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebTesting.BL.DbConnection;

namespace WebTesting.BL.Behaviors.Tests.DeleteQuestion;

public class DeleteQuestionHandler : IRequestHandler<DeleteQuestionCommand>
{
    private readonly DataContext _context;

    public DeleteQuestionHandler(DataContext context)
    {
        _context = context;
    }

    public async Task Handle(DeleteQuestionCommand request, CancellationToken cancellationToken)
    {
        var question = await _context.Questions.FirstOrDefaultAsync(t => t.Id == request.Id, cancellationToken);

        if (question is null)
        {
            throw new Exception("Question not found");
        }

        _context.Questions.Remove(question);
        await _context.SaveChangesAsync(cancellationToken);
    }
}
