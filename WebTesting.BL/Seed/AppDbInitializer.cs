using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebTesting.BL.DbConnection;
using WebTesting.Domain.Entities;
using WebTesting.Domain.Enums;

namespace WebTesting.BL.Seed;

public static class AppDbInitializer
{
    public static void Seed(IApplicationBuilder applicationBuilder, IConfiguration configuration)
    {
        using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
        {
            var context = serviceScope.ServiceProvider.GetService<DataContext>();

            context.Database.EnsureCreated();

            if(!context.Users.Where(t => t.Role == Role.Admin).Any())
            {
                context.Users.Add(new User { 
                    Id = Guid.NewGuid(),
                    Role = Role.Admin,
                    UserName = "Admin",
                    FirstName = "Admin",
                    LastName = "Account",
                    Email = "admin@gmail.com",
                    NormalizedEmail = "ADMIN@GMAIL.COM",
                    PasswordHash = configuration.GetSection("SeedInfo:PasswordHash").Value,
                    SecurityStamp = configuration.GetSection("SeedInfo:SecurityStamp").Value,
                    ConcurrencyStamp = configuration.GetSection("SeedInfo:ConcurrencyStamp").Value,
                    LockoutEnabled = true
                });
                context.SaveChanges();
            }
         }
    }
}

