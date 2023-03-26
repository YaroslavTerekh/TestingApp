using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebTesting.Domain.Entities;

namespace WebTesting.Domain.Configurations;

public class TestConfiguration : IEntityTypeConfiguration<Test>
{
    public void Configure(EntityTypeBuilder<Test> builder)
    {
        builder.HasMany(t => t.Users)
            .WithMany(t => t.Tests);

        builder.HasMany(t => t.Questions)
            .WithOne(t => t.Test)
            .HasForeignKey(t => t.TestId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
