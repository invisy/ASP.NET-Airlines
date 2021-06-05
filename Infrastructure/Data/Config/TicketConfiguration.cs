using Airlines.ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Airlines.Infrastructure.Data.Config
{
    public class TicketConfiguration : IEntityTypeConfiguration<Ticket>
    {
        public void Configure(EntityTypeBuilder<Ticket> builder)
        {
            builder.HasKey(x => x.Id);
            builder.ToTable("Tickets");
            
            builder.OwnsOne(o => o.Passenger, a =>
            {
                a.WithOwner();
                
                a.Property(a => a.Name)
                    .HasMaxLength(50)
                    .IsRequired();

                a.Property(a => a.Surname)
                    .HasMaxLength(50)
                    .IsRequired();

                a.Property(a => a.Patronymic)
                    .HasMaxLength(50)
                    .IsRequired();

                a.Property(a => a.Age)
                    .IsRequired();

                a.Property(a => a.UniquePassportId)
                    .HasMaxLength(9)
                    .IsRequired();
            });
        }
    }
}