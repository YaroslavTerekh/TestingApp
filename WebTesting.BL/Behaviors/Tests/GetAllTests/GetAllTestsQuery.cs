using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebTesting.Domain.DataTransferObjects;

namespace WebTesting.BL.Behaviors.Tests.GetAllTests;

public class GetAllTestsQuery : IRequest<List<TestDTO>>
{
    public Guid CurrentUserId { get; set; }

    public GetAllTestsQuery(Guid id) => CurrentUserId = id;
}
