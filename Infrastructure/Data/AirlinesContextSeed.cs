using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Airlines.ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Airlines.Infrastructure.Data
{
    public class AirlinesContextSeed
    {
        public static async Task SeedAsync(AirlinesContext airlinesContext)
        {
            if (!await airlinesContext.Cities.AnyAsync())
            {
                await airlinesContext.Cities.AddRangeAsync(
                    GetPreconfiguredCities());

                await airlinesContext.SaveChangesAsync();
            }
        }
        
        static IEnumerable<City> GetPreconfiguredCities()
        {
            return new List<City>()
            {
                new City("Київ"),
            };
        }
    }
}