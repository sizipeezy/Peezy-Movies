namespace PeezyMovies.Infrastructure.Data.Configuration
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.Extensions.DependencyInjection;
    using PeezyMovies.Infrastructure.Data.Models;

    public class AdminConfiguration
    {

        public static async void SeedAdmin(IApplicationBuilder applicationBuilder)
        {
            using( var service = applicationBuilder.ApplicationServices.CreateScope())
            {
                var roleManager = service.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                if (!await roleManager.RoleExistsAsync(WebAppDataConstants.Admin))
                {
                    await roleManager.CreateAsync(new IdentityRole(WebAppDataConstants.Admin));
                }

                var userManager = service.ServiceProvider.GetRequiredService<UserManager<User>>();
                string adminEmail = "admin@pmovies.com";

                var adminUser = await userManager.FindByEmailAsync(adminEmail);
                if(adminUser == null)
                {
                    var admin = new User()
                    {
                        UserName = "admin-user",
                        Email = adminEmail,
                        EmailConfirmed = true,

                    };

                    await userManager.CreateAsync(admin, "admin-pass");
                    await userManager.AddToRoleAsync(admin, WebAppDataConstants.Admin);
                }

            }
        }
    }
}
