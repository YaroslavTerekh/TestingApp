using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebTesting.Domain.DataTransferObjects;

public class ResultDTO
{
    public Guid Id { get; set; }

    public string TestTitle { get; set; }

    public int TotalQuestions { get; set; }

    public int Point { get; set; }
}
