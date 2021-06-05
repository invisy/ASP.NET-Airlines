using System.Threading.Tasks;
using Airlines.ApplicationCore.Constants;
using Microsoft.AspNetCore.Identity;

namespace Airlines.Infrastructure.Identity
{
    public class AppIdentityDbContextSeed
    {
        public static async Task SeedAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            await roleManager.CreateAsync(new IdentityRole(Roles.USERS));
            await roleManager.CreateAsync(new IdentityRole(Roles.ADMINISTRATORS));

            var defaultUser = new ApplicationUser { UserName = "user1@airlines.com", Email = "user1@airlines.com", Name = "Іван", Surname = "Іванов", Patronymic = "Іванович"};
            await userManager.CreateAsync(defaultUser, AuthorizationConstants.DEFAULT_PASSWORD);
            await userManager.AddToRoleAsync(defaultUser, Roles.USERS);
            

            string adminUserName = "admin@airlines.com";
            var adminUser = new ApplicationUser { UserName = adminUserName, Email = adminUserName, Name = "Петро", Surname = "Петров", Patronymic = "Петрович" };
            await userManager.CreateAsync(adminUser, AuthorizationConstants.DEFAULT_PASSWORD);
            await userManager.AddToRoleAsync(adminUser, Roles.ADMINISTRATORS);
        }
    }
}