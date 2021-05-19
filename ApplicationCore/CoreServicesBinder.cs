using Airlines.ApplicationCore.DTOs;
using Airlines.ApplicationCore.Entities;
using Airlines.ApplicationCore.Interfaces;
using Airlines.ApplicationCore.Mappers;
using Airlines.ApplicationCore.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Airlines.ApplicationCore
{
    public static class CoreServicesBinder
    {
        public static IServiceCollection BindCoreLayer(this IServiceCollection services)
        {
            services.AddScoped<IMapper<City, CityDTO>, CityMapper>();
            services.AddScoped<IFlightsService, FlightsService>();
            services.AddScoped<ICitiesService, CitiesService>();
            
            return services;
        }
    }
}