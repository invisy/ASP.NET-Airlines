using System;
using Airlines.ApplicationCore.Entities;
using Airlines.Infrastructure.Data.Interafaces;
using Microsoft.EntityFrameworkCore;

namespace IntegrationTests
{
    public class DbContextTestSeeder : IDbContextSeeder
    {
        public void Seed(ModelBuilder modelBuilder)
        {
            //City
            modelBuilder.Entity<City>()
                .HasData(
                    new {Id=1, Name="Київ"},
                    new {Id=2, Name="Харків"},
                    new {Id=3, Name="Львів"}
                );
            
            //TravelClass
            modelBuilder.Entity<TravelClass>()
                .HasData(
                    new {Id = 1, Name = "Економ", ClassPrice = (float)0},
                    new {Id = 2, Name = "Бізнес", ClassPrice = (float)100},
                    new {Id = 3, Name = "Перший", ClassPrice = (float)1000}
                );
            
            //Plane
            modelBuilder.Entity<Plane>()
                .HasData(
                    new {Id = 1, Name = "Airbus", Model = "A318", TotalSeats = 5},
                    new {Id = 2, Name = "Airbus", Model = "A220-100", TotalSeats = 5}
                );
            
            modelBuilder.Entity<Plane>()
                .HasMany(p => p.TravelClasses)
                .WithMany(p => p.Planes)
                .UsingEntity(j => j.HasData(
                    new {PlanesId = 1, TravelClassesId = 1},
                    new {PlanesId = 1, TravelClassesId = 2},
                    new {PlanesId = 1, TravelClassesId = 3},
                    new {PlanesId = 2, TravelClassesId = 1},
                    new {PlanesId = 2, TravelClassesId = 2},
                    new {PlanesId = 2, TravelClassesId = 3}
                ));
            
            //Flight
            modelBuilder.Entity<Flight>()
                .HasData(
                    new {Id = 1, DepartureCityId = 1, IncomingCityId = 2, FlightPrice = (float)100, PlaneId=1},
                    new {Id = 2, DepartureCityId = 2, IncomingCityId = 1, FlightPrice = (float)100, PlaneId=1},
                    new {Id = 3, DepartureCityId = 1, IncomingCityId = 3, FlightPrice = (float)200, PlaneId=2}
                );
            
            //FlightInstance
            DateTime date1 = new DateTime(2021, 6, 01, 12, 00, 00);
            DateTime date2 = new DateTime(2021, 6, 01, 13, 10, 00);
            
            modelBuilder.Entity<FlightInstance>()
                .HasData(
                    new { Id = 1, DepartureDate = date1, IncomingDate = date2, FlightId = 1 },
                    new { Id = 2, DepartureDate = date1.AddHours(2), IncomingDate = date2.AddHours(2), FlightId = 2 },
                    new { Id = 3, DepartureDate = date1.AddDays(1), IncomingDate = date2.AddDays(1), FlightId = 1 },
                    new { Id = 4, DepartureDate = date1, IncomingDate = date2, FlightId = 3 }
                );
            
            //PlaneSeats

            modelBuilder.Entity<PlaneSeat>()
                .HasData(
                    new { Id = 1, Number="1-A", TravelClassId = 1, FlightInstanceId = 1 },
                    new { Id = 2, Number="1-Б", TravelClassId = 1, FlightInstanceId = 1 },
                    new { Id = 3, Number="2-A", TravelClassId = 1, FlightInstanceId = 1 },
                    new { Id = 4, Number="2-Б", TravelClassId = 1, FlightInstanceId = 1 },
                    new { Id = 5, Number="3-А", TravelClassId = 2, FlightInstanceId = 1 },
                    new { Id = 6, Number="1-A", TravelClassId = 1, FlightInstanceId = 2 },
                    new { Id = 7, Number="1-Б", TravelClassId = 1, FlightInstanceId = 2 },
                    new { Id = 8, Number="2-A", TravelClassId = 1, FlightInstanceId = 2 },
                    new { Id = 9, Number="2-Б", TravelClassId = 1, FlightInstanceId = 2 },
                    new { Id = 10, Number="3-А", TravelClassId = 2, FlightInstanceId = 2 },
                    new { Id = 11, Number="1-A", TravelClassId = 1, FlightInstanceId = 3 },
                    new { Id = 12, Number="1-Б", TravelClassId = 1, FlightInstanceId = 3 },
                    new { Id = 13, Number="2-A", TravelClassId = 1, FlightInstanceId = 3 },
                    new { Id = 14, Number="2-Б", TravelClassId = 2, FlightInstanceId = 3 },
                    new { Id = 15, Number="3-А", TravelClassId = 3, FlightInstanceId = 3 },
                    new { Id = 16, Number="1-A", TravelClassId = 1, FlightInstanceId = 4 },
                    new { Id = 17, Number="1-Б", TravelClassId = 1, FlightInstanceId = 4 },
                    new { Id = 18, Number="2-A", TravelClassId = 2, FlightInstanceId = 4 },
                    new { Id = 19, Number="2-Б", TravelClassId = 2, FlightInstanceId = 4 },
                    new { Id = 20, Number="3-А", TravelClassId = 3, FlightInstanceId = 4 }
                );
        }
    }
}