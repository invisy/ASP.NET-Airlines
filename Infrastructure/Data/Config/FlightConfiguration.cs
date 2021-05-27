using Airlines.ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Airlines.Infrastructure.Data.Config
{
    public class FlightConfiguration : IEntityTypeConfiguration<Flight>
    {
        public void Configure(EntityTypeBuilder<Flight> builder)
        {
            builder.HasKey(x => x.Id);
            
            builder.HasOne(x => x.DepartureCity)
                .WithMany()
                .HasForeignKey(x => x.DepartureCityId)
                .OnDelete(DeleteBehavior.Restrict);
            
            builder.HasOne(x => x.IncomingCity)
                .WithMany()
                .HasForeignKey(x => x.IncomingCityId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Plane)
                .WithMany()
                .HasForeignKey(x => x.PlaneId);

            builder.ToTable("Flights");
        }
    }
}