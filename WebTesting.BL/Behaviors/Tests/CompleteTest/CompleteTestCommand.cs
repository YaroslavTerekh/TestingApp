using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using WebTesting.Domain.DataTransferObjects;

namespace WebTesting.BL.Behaviors.Tests.CompleteTest;

public class CompleteTestCommand : IRequest<ResultDTO>
{
    [JsonIgnore]
    public Guid CurrentUserId { get; set; }

    public Guid Id { get; set; }    

    public List<CheckAnswerDTO> CheckAnswers { get; set; }
}
