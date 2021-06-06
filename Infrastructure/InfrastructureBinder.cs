using Airlines.ApplicationCore.Entities;
using Airlines.ApplicationCore.Interfaces;
using Airlines.Infrastructure.Data;
using Airlines.Infrastructure.Data.Interafaces;
using Airlines.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Airlines.Infrastructure
{
    public static class InfrastructureBinder
    {
        public static IServiceCollection BindInfrastructureLayer(this IServiceCollection services, string connectionString, string identityConnectionString)
        {
            services.AddScoped(typeof(IAsyncRepository<,>), typeof(GenericRepository<,>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            
            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddDefaultUI()
                .AddEntityFrameworkStores<AppIdentityDbContext>()
                .AddDefaultTokenProviders();

            services.AddScoped<IDbContextSeeder, DbContextSeeder>();
            
            services.AddDbContext<AirlinesContext>(options =>
                options.UseSqlServer(connectionString));

            services.AddDbContext<AppIdentityDbContext>(options =>
                options.UseSqlServer(identityConnectionString));

            return services;
        }
    }
}