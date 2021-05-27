using Airlines.ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Airlines.Infrastructure.Data.Config
{
    public class TravelClassConfiguration : IEntityTypeConfiguration<TravelClass>
    {
        public void Configure(EntityTypeBuilder<TravelClass> builder)
        {
            builder.HasKey(x => x.Id);
            builder.ToTable("TravelClasses");
        }
    }
}