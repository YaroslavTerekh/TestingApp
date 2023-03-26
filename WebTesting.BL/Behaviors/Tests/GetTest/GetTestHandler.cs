using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebTesting.BL.DbConnection;
using WebTesting.Domain.DataTransferObjects;
using WebTesting.Domain.Enums;

namespace WebTesting.BL.Behaviors.Tests.GetTest
{
    public class GetTestHandler : IRequestHandler<GetTestQuery, TestDTO>
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public GetTestHandler(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<TestDTO> Handle(GetTestQuery request, CancellationToken cancellationToken)
        {
            var test = await _context.Tests
                .Include(t => t.Questions)
                    .ThenInclude(t => t.Options)
                .Include(t => t.Users)
                .FirstOrDefaultAsync(t => t.Id == request.Id, cancellationToken);

            if(test is null)
            {
                throw new Exception("Test not found");
            }

            if(await _context.Users.Where(t => t.Id == request.CurrentUserId).Select(t => t.Role).FirstOrDefaultAsync(cancellationToken) != Role.Admin &&
                !test.Users.Select(t => t.Id).ToList().Contains(request.CurrentUserId))
            {
                throw new Exception("You can pass only your tests");
            }

            return _mapper.Map<TestDTO>(test);
        }
    }
}
