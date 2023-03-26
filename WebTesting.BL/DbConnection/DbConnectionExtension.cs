using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace WebTesting.BL.DbConnection
{
    public static class DbConnectionExtension
    {
        public static IServiceCollection AddDbContextsCustom(this IServiceCollection services, IConfiguration builder)
        {
            services.AddDbContext<DataContext>(
                o => o.UseSqlServer(builder.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly("WebTesting.Backend")));
            return services;
        }
    }
}
