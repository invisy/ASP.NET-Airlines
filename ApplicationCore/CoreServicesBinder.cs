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
            services.AddScoped<IMapper<TravelClass, TravelClassDTO>, TravelClassMapper>();
            services.AddScoped<IMapper<City, CityDTO>, CityMapper>();
            services.AddScoped<IMapper<Plane, PlaneDTO>, PlaneMapper>();
            services.AddScoped<IMapper<Plane, PlaneOverviewDTO>, PlaneOverviewMapper>();
            services.AddScoped<IMapper<Plane, PlaneFlatDTO>, PlaneFlatMapper>();
            services.AddScoped<IFlightsService, FlightsService>();
            services.AddScoped<ICitiesService, CitiesService>();
            services.AddScoped<ITravelClassesService, TravelClassesService>();
            services.AddScoped<IPlanesService, PlanesService>();
            
            return services;
        }
    }
}