using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebTesting.Domain.Entities
{
    public class Test : BaseEntity
    {
        public string Title { get; set; }

        public string Description { get; set; }
        
        public List<Question> Questions { get; set; } = new();

        public List<User> Users { get; set; } = new();
    }
}
