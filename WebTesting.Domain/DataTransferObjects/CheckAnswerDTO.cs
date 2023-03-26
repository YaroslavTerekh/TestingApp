using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebTesting.Domain.DataTransferObjects;

public class CheckAnswerDTO 
{
    public Guid QuestionId { get; set; }

    public Guid OptionId { get; set; }
}
