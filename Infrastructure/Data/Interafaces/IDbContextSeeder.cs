using Microsoft.EntityFrameworkCore;

namespace Airlines.Infrastructure.Data.Interafaces
{
    public interface IDbContextSeeder
    {
        void Seed(ModelBuilder modelBuilder);
    }
}