using System.Reflection;
using System.Runtime.CompilerServices;
using Airlines.ApplicationCore.Entities;
using Airlines.Infrastructure.Data.Config;
using Microsoft.EntityFrameworkCore;

namespace Airlines.Infrastructure.Data
{
    public class AirlinesContext : DbContext
    {
        public DbSet<City> Cities;
        public DbSet<TravelClass> TravelClasses;
        public DbSet<Plane> Planes;
        public DbSet<PlaneSeat> PlaneSeats;
        public DbSet<Flight> Flights;
        public DbSet<FlightInstance> FlightInstances;
        public DbSet<Passenger> Passengers;
        public DbSet<Ticket> Tickets;
        
        public AirlinesContext(DbContextOptions<AirlinesContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}