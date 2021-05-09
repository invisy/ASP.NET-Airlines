using Airlines.Infrastructure.Data;
using Airlines.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Airlines.Infrastructure
{
    public static class InfrastructureBinder
    {
        public static IServiceCollection BindInfrastructureLayer(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<AirlinesContext>(options =>
                options.UseSqlServer(connectionString));
            services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<AirlinesContext>();

            return services;
        }
    }
}