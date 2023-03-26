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

namespace WebTesting.BL.Behaviors.Tests.GetMyTests;

public class GetMyTestsHandler : IRequestHandler<GetMyTestsQuery, List<TestDTO>>
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;

    public GetMyTestsHandler(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<TestDTO>> Handle(GetMyTestsQuery request, CancellationToken cancellationToken)
    {
        return await _context.Tests
            .Where(t => t.Users.Select(t => t.Id).Contains(request.CurrentUserId))
            .Include(t => t.Questions)
                .ThenInclude(t => t.Options)
            .Select(t => _mapper.Map<TestDTO>(t))
            .ToListAsync(cancellationToken);
    }
}
