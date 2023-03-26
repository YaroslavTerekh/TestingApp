using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebTesting.Domain;
using WebTesting.Domain.Configurations;
using WebTesting.Domain.Entities;

namespace WebTesting.BL.DbConnection
{
    public class DataContext : IdentityDbContext<User, ApplicationRole, Guid>
    {
        public DataContext(DbContextOptions<DataContext> opts) : base(opts) { }


        public DbSet<Test> Tests { get; set; }

        public DbSet<Question> Questions { get; set; }

        public DbSet<Option> Options { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new TestConfiguration());
            builder.ApplyConfiguration(new QuestionConfiguration());
        }
    }
}
