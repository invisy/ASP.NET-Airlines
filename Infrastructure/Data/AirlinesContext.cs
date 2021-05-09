using System.Runtime.CompilerServices;
using Microsoft.EntityFrameworkCore;

namespace Airlines.Infrastructure.Data
{
    public class AirlinesContext : DbContext
    { 
        public AirlinesContext(DbContextOptions<AirlinesContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}