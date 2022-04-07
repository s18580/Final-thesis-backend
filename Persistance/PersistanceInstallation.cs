using Application.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistance.Context;

namespace Persistance
{
    public static class PersistanceInstallation
    {
        public static IServiceCollection AddPersistanceLayer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ModelContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DatabaseMSSQL")));

            services.AddScoped<IApplicationContext>(provider => provider.GetService<ModelContext>());

            return services;
        }
    }
}
