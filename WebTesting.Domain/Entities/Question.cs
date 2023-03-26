using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebTesting.Domain.Entities
{
    public class Question : BaseEntity
    {
        public string QuestionDescription { get; set; }

        public List<Option> Options { get; set; } = new();

        public Guid TestId { get; set; }

        public Test Test { get; set; }
    }
}
