using Airlines.Infrastructure.Data;
using Airlines.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Airlines.Infrastructure
{
    public static class InfrastructureBinder
    {
        public static IServiceCollection BindInfrastructureLayer(this IServiceCollection services, string connectionString, string identityConnectionString)
        {
            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddDefaultUI()
                .AddEntityFrameworkStores<AppIdentityDbContext>()
                .AddDefaultTokenProviders();
            
            /*
            services.AddDbContext<AirlinesContext>(options =>
                options.UseSqlServer(connectionString));

            services.AddDbContext<AppIdentityDbContext>(options =>
                options.UseSqlServer(identityConnectionString));
            */
            
            services.AddDbContext<AirlinesContext>(options =>
                options.UseInMemoryDatabase(databaseName: "Test"));

            services.AddDbContext<AppIdentityDbContext>(options =>
                options.UseInMemoryDatabase(databaseName: "TestIdentity"));

            return services;
        }
    }
}