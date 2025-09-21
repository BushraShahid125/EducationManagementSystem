using EducationManagementSystem.Common;
using EducationManagementSystem.Models;
using Microsoft.AspNetCore.Identity;
using static Azure.Core.HttpHeader;
using static EducationManagementSystem.Common.Enums;

namespace Test.Data
{
    public class DataSeeder
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly ILogger<DataSeeder> _logger;

        public DataSeeder(IServiceProvider serviceProvider, ILogger<DataSeeder> logger)
        {
            _serviceProvider = serviceProvider;
            _logger = logger;
        }

        public async Task SeedAsync()
        {
            using var scope = _serviceProvider.CreateScope();

            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            foreach (var roleName in Enum.GetNames(typeof(ApplicationUserTypeEnum)))
            {
                if (!await roleManager.RoleExistsAsync(roleName))
                {
                    await roleManager.CreateAsync(new IdentityRole(roleName));
                }
            }
            await CreateUserAsync(userManager,
                "admin@example.com",
                "Admin@123",
                "System Administrator",
                ApplicationUserTypeEnum.Admin.ToString(),
                "F");
        }

        private async Task CreateUserAsync(UserManager<ApplicationUser> userManager, string email, string password, string fullName, string role, string gender)
        {
            if (await userManager.FindByEmailAsync(email) == null)
            {
                var user = new ApplicationUser
                {
                    UserName = email,
                    Email = email,
                    EmailConfirmed = true,
                    FirstName = fullName,
                    ApplicationUserTypeId = (int)Enums.ApplicationUserTypeEnum.Admin,
                };

                var result = await userManager.CreateAsync(user, password);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, role);
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        _logger.LogError("Failed to create {Role} user: {Error}", role, error.Description);
                    }
                }
            }
        }
    }
}

