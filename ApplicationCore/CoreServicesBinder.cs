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
            services.AddScoped<IMapper<FlightInstance, FoundFlightsDTO>, FoundFlightsMapper>();
            services.AddScoped<IMapper<PlaneSeat, PlaneSeatFlatDTO>, PlaneSeatFlatMapper>();
            
            services.AddScoped<ICitiesService, CitiesService>();
            services.AddScoped<ITravelClassesService, TravelClassesService>();
            services.AddScoped<IPlanesService, PlanesService>();
            services.AddScoped<IAirportService, AirportService>();
            
            return services;
        }
    }
}