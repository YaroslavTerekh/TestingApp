using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using WebTesting.Domain.DataTransferObjects;

namespace WebTesting.BL.Behaviors.Tests.GetTest
{
    public class GetTestQuery : IRequest<TestDTO>
    {
        [JsonIgnore]
        public Guid CurrentUserId { get; set; }

        [JsonIgnore]
        public Guid Id { get; set; }

        public GetTestQuery(Guid currentUserId, Guid id)
        {
            CurrentUserId = currentUserId;
            Id = id;
        }
    }
}
