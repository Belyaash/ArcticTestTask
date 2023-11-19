using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services,
    IConfiguration configuration)
        {
            var connectionString = configuration["DbConnection"];
            services.AddDbContext<MaterialsDbContext>(options =>
            {
                options.UseNpgsql(connectionString);
            });
            services.AddScoped<IMaterialsDbContext>(provider =>
                provider.GetService<MaterialsDbContext>());
            return services;
        }
    }
}
