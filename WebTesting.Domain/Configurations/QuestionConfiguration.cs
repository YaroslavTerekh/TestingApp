using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebTesting.Domain.Entities;

namespace WebTesting.Domain.Configurations;

public class QuestionConfiguration : IEntityTypeConfiguration<Question>
{
    public void Configure(EntityTypeBuilder<Question> builder)
    {
        builder.HasOne(t => t.Test)
            .WithMany(t => t.Questions)
            .HasForeignKey(t => t.TestId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(t => t.Options)
            .WithOne(t => t.Question)
            .HasForeignKey(t => t.QuestionId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
