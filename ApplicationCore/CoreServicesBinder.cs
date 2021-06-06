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
            services.AddSingleton<IMapper<TravelClass, TravelClassDTO>, TravelClassMapper>();
            services.AddSingleton<IMapper<City, CityDTO>, CityMapper>();
            services.AddSingleton<IMapper<Plane, PlaneDTO>, PlaneMapper>();
            services.AddSingleton<IMapper<Plane, PlaneOverviewDTO>, PlaneOverviewMapper>();
            services.AddSingleton<IMapper<Plane, PlaneFlatDTO>, PlaneFlatMapper>();
            services.AddSingleton<IMapper<FlightInstance, FoundFlightsDTO>, FoundFlightsMapper>();
            services.AddSingleton<IMapper<PlaneSeat, PlaneSeatFlatDTO>, PlaneSeatFlatMapper>();
            
            services.AddScoped<ICitiesService, CitiesService>();
            services.AddScoped<ITravelClassesService, TravelClassesService>();
            services.AddScoped<IPlanesService, PlanesService>();
            services.AddScoped<IAirportService, AirportService>();
            
            return services;
        }
    }
}