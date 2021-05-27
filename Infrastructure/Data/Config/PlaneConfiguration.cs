using Airlines.ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Airlines.Infrastructure.Data.Config
{
    public class PlaneConfiguration : IEntityTypeConfiguration<Plane>
    {
        public void Configure(EntityTypeBuilder<Plane> builder)
        {
            builder.HasKey(x => x.Id);
            builder.ToTable("Planes");
            builder
                .HasMany(p => p.TravelClasses)
                .WithMany(p => p.Planes)
                .UsingEntity(j => j.ToTable("PlanesTravelClasses"));
        }
    }
}