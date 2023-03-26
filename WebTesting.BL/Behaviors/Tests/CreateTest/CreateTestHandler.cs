using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebTesting.BL.DbConnection;
using WebTesting.Domain.Entities;

namespace WebTesting.BL.Behaviors.Tests.CreateTest
{
    public class CreateTestHandler : IRequestHandler<CreateTestCommand>
    {
        private readonly DataContext _context;

        public CreateTestHandler(DataContext context)
        {
            _context = context;
        }

        public async Task Handle(CreateTestCommand request, CancellationToken cancellationToken)
        {
            var newTest = new Test
            {
                Title = request.Title,
                Description = request.Description,
                Users = await _context.Users.Where(t => request.UserIds.Contains(t.Id)).ToListAsync(cancellationToken),
            };

            await _context.Tests.AddAsync(newTest, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
