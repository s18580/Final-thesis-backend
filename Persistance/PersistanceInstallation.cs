using Application.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Persistance.Context;
using Persistance.Security;
using System.Text;

namespace Persistance
{
    public static class PersistanceInstallation
    {
        public static IServiceCollection AddPersistanceLayer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ModelContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DatabaseMSSQL")));

            services.AddScoped<IApplicationContext>(provider => provider.GetService<ModelContext>());
            services.AddScoped<IAuthenticationService, AuthenticationService>();
            services.AddScoped<IAuthorizationService, AuthorizationService>();
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                    .AddJwtBearer(options => {
                        options.TokenValidationParameters = new TokenValidationParameters
                        {
                            ValidateIssuerSigningKey = true,
                            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["SecretIssuerKey"])),
                            ValidateIssuer = false,
                            ValidateAudience = false,
                        };
                    });

            return services;
        }
    }
}
