using MediatR;
using Microsoft.EntityFrameworkCore;
using WebTesting.BL.DbConnection;
using WebTesting.Domain.Entities;

namespace WebTesting.BL.Behaviors.Tests.ModifyTest;

public class ModifyTestHandler : IRequestHandler<ModifyTestCommand>
{
    private readonly DataContext _context;

    public ModifyTestHandler(DataContext context)
    {
        _context = context;
    }

    public async Task Handle(ModifyTestCommand request, CancellationToken cancellationToken)
    {
        var test = await _context.Tests
            .Include(t => t.Users)
            .FirstOrDefaultAsync(t => t.Id == request.Id);

        if(test is null)
        {
            throw new Exception("Test not found");
        }

        List<User> users = new List<User>();

        foreach (var id in request.UserIds)
            users.Add(await _context.Users.FirstOrDefaultAsync(t => t.Id == id, cancellationToken));

        test.Title = request.Title;
        test.Description = request.Description;
        test.Users = users;

        await _context.SaveChangesAsync(cancellationToken);
    }
}
