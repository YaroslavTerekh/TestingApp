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

namespace WebTesting.BL.Behaviors.Tests.GetAllTests;

public class GetAllTestsHandler : IRequestHandler<GetAllTestsQuery, List<TestDTO>>
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;

    public GetAllTestsHandler(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<TestDTO>> Handle(GetAllTestsQuery request, CancellationToken cancellationToken)
    {
        return await _context.Tests
            .Include(t => t.Users)
            .Include(t => t.Questions)
                .ThenInclude(t => t.Options)
            .Select(t => _mapper.Map<TestDTO>(t))
            .ToListAsync(cancellationToken);
    }
}
