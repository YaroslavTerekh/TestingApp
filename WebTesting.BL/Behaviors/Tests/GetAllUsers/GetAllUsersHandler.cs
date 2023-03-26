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

namespace WebTesting.BL.Behaviors.Tests.GetAllUsers;

public class GetAllUsersHandler : IRequestHandler<GetAllUsersQuery, List<UserDTO>>
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;

    public GetAllUsersHandler(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<UserDTO>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
    {
        return await _context.Users
            .Where(t => t.Role == Role.SimpleUser)
            .Select(t => _mapper.Map<UserDTO>(t))
            .ToListAsync(cancellationToken);
    }
}
