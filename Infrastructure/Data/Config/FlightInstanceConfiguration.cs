using Airlines.ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Airlines.Infrastructure.Data.Config
{
    public class FlightInstanceConfiguration : IEntityTypeConfiguration<FlightInstance>
    {
        public void Configure(EntityTypeBuilder<FlightInstance> builder)
        {
            builder.HasKey(x => x.Id);
            
            builder.HasOne(x => x.Flight)
                .WithMany()
                .HasForeignKey(x => x.FlightId)
                ;
            
            builder.ToTable("FlightInstances");
        }
    }
}