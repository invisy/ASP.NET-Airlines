using Airlines.ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Airlines.Infrastructure.Data.Config
{
    public class PlaneSeatConfiguration : IEntityTypeConfiguration<PlaneSeat>
    {
        public void Configure(EntityTypeBuilder<PlaneSeat> builder)
        {
            builder.HasKey(x => x.Id);
            builder.ToTable("PlaneSeats");
            builder.HasOne(x => x.TravelClass)
                .WithMany()
                .HasForeignKey(x => x.TravelClassId);
            
            builder.HasOne(x => x.Ticket)
                .WithMany()
                .HasForeignKey(x => x.TicketId);
        }
    }
}