using Airlines.ApplicationCore.Interfaces;
using Airlines.ApplicationCore.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Airlines.ApplicationCore
{
    public static class CoreServicesBinder
    {
        public static IServiceCollection BindCoreLayer(this IServiceCollection services)
        {
            services.AddScoped<IFlightsService, FlightsService>();
                    
            return services;
        }
    }
}