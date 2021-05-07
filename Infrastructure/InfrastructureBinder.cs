using Airlines.Infrastructure.Data;
using Airlines.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Airlines.Infrastructure
{
    public static class InfrastructureBinder
    {
        public static IServiceCollection BindInfrastructureLayer(this IServiceCollection services)
        {
            services.AddDbContext<AirlinesContext>(options =>
                options.UseSqlServer(@"Server=localhost;Database=airportDb;Trusted_Connection=True;"));
            services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<AirlinesContext>();

            return services;
        }
    }
}