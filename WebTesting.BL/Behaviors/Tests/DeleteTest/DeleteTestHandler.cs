using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebTesting.BL.DbConnection;

namespace WebTesting.BL.Behaviors.Tests.DeleteTest;

public class DeleteTestHandler : IRequestHandler<DeleteTestCommand>
{
    private readonly DataContext _context;

    public DeleteTestHandler(DataContext context)
    {
        _context = context;
    }

    public async Task Handle(DeleteTestCommand request, CancellationToken cancellationToken)
    {
        var test = await _context.Tests.FirstOrDefaultAsync(t => t.Id == request.Id, cancellationToken);

        if (test is null)
        {
            throw new Exception("Test not found");
        }

        _context.Tests.Remove(test);
        await _context.SaveChangesAsync(cancellationToken);
    }
}
