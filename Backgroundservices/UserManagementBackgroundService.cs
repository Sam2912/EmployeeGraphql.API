using EmployeeGraphql.API.DbContext;
using Microsoft.AspNetCore.Identity;

namespace EmployeeGraphql.API.Backgroundservices
{
    public class UserManagementBackgroundService : BackgroundService
    {
        private readonly IServiceProvider _serviceProvider;

        public UserManagementBackgroundService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
                var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                // Your logic for user and role creation and assignment goes here
                var adminRoleExists = await roleManager.RoleExistsAsync("Admin");
                if (!adminRoleExists)
                {
                    await roleManager.CreateAsync(new IdentityRole("Admin"));
                }

                var itRoleExists = await roleManager.RoleExistsAsync("IT");
                if (!itRoleExists)
                {
                    await roleManager.CreateAsync(new IdentityRole("IT"));
                }

                var userExists = await userManager.FindByNameAsync("lax.cha29");
                if (userExists == null)
                {
                    var adminUser = new ApplicationUser { UserName = "lax.cha29", Email = "lax.cha29@gmail.com" };
                    await userManager.CreateAsync(adminUser, "Test@123"); // Replace "Admin@123" with a secure password
                    await userManager.AddToRoleAsync(adminUser, "Admin");
                    await userManager.AddToRoleAsync(adminUser, "IT");
                }

                var userExists2 = await userManager.FindByNameAsync("lax.prat");
                if (userExists2 == null)
                {
                    var itUser = new ApplicationUser { UserName = "lax.prat", Email = "lax.prat@gmail.com" };
                    await userManager.CreateAsync(itUser, "Test@123"); // Replace "Admin@123" with a secure password
                    await userManager.AddToRoleAsync(itUser, "IT");
                }

            }

            await Task.CompletedTask;
        }
    }

}