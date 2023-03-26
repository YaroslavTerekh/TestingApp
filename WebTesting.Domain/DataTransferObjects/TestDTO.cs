using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebTesting.Domain.DataTransferObjects
{
    public class TestDTO
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public List<QuestionDTO> Questions { get; set; } = new();

        public List<UserDTO> Users { get; set; }
    }
}
