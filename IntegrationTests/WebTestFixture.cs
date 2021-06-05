using System;
using System.Linq;
using Airlines.Infrastructure.Data;
using Airlines.Infrastructure.Data.Interafaces;
using Airlines.Infrastructure.Identity;
using Airlines.Web;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace IntegrationTests
{
    public class WebTestFixture : WebApplicationFactory<Startup>
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                RemoveAirlinesDbContextRegistration(services);
                RemoveIdentityDbContextRegistration(services);
                RemoveAirlinesDbContextSeeder(services);

                var serviceProvider = GetInMemoryServiceProvider();

                services.AddDbContext<AirlinesContext>(options =>
                {
                    options.UseInMemoryDatabase("InMemoryDbForTesting");
                    options.UseInternalServiceProvider(serviceProvider);
                });

                services.AddScoped<IDbContextSeeder, DbContextTestSeeder>();
                
                services.AddDbContext<AppIdentityDbContext>(options =>
                {
                    options.UseInMemoryDatabase("Identity");
                    options.UseInternalServiceProvider(serviceProvider);
                });

                var sp = services.BuildServiceProvider();
                
                using (var scope = sp.CreateScope())
                {
                    var scopedServices = scope.ServiceProvider;
                    var db = scopedServices.GetRequiredService<AirlinesContext>();

                    try
                    {
                        // seed sample user data
                        var userManager = scopedServices.GetRequiredService<UserManager<ApplicationUser>>();
                        var roleManager = scopedServices.GetRequiredService<RoleManager<IdentityRole>>();
                        AppIdentityDbContextSeed.SeedAsync(userManager, roleManager).Wait();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"An error occurred seeding the database with test messages. Error: {ex.Message}");
                    }
                }
                
            });
        }
        
        private static ServiceProvider GetInMemoryServiceProvider()
        {
            return new ServiceCollection()
                .AddEntityFrameworkInMemoryDatabase()
                .BuildServiceProvider();
        }

        private static void RemoveAirlinesDbContextRegistration(IServiceCollection services)
        {
            var descriptor = services.SingleOrDefault(
                d => d.ServiceType ==
                     typeof(DbContextOptions<AirlinesContext>));

            if (descriptor != null)
            {
                services.Remove(descriptor);
            }
        }
        
        private static void RemoveAirlinesDbContextSeeder(IServiceCollection services)
        {
            var descriptor = services.SingleOrDefault(
                d => d.ServiceType ==
                     typeof(IDbContextSeeder));

            if (descriptor != null)
            {
                services.Remove(descriptor);
            }
        }
        
        private static void RemoveIdentityDbContextRegistration(IServiceCollection services)
        {
            var descriptor = services.SingleOrDefault(
                d => d.ServiceType ==
                     typeof(DbContextOptions<IdentityDbContext>));

            if (descriptor != null)
            {
                services.Remove(descriptor);
            }
        }
    }
}