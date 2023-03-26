using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebTesting.Domain.DataTransferObjects;

namespace WebTesting.BL.Behaviors.Tests.GetMyTests; 

public class GetMyTestsQuery : IRequest<List<TestDTO>>
{
    public Guid CurrentUserId { get; set; }

    public GetMyTestsQuery(Guid id) => CurrentUserId = id;
}
