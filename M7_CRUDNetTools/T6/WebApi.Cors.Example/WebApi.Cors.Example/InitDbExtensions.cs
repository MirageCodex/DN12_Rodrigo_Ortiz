using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Cors.Example
{
    public static class InitDbExtensions
    {
        public static async Task<IApplicationBuilder> InitDbAsync(this IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices.CreateScope())
            {
                var services = scope.ServiceProvider;
                var userManager = services.GetRequiredService<UserManager<IdentityUser>>();
                var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

                if (!userManager.Users.Any())
                {
                    await InitRolesAsync(roleManager);
                    await InitUsersAsync(userManager);
                }
            }
            return app;
        }

        private static async Task InitRolesAsync(RoleManager<IdentityRole> roleManager)
        {
            await roleManager.CreateAsync(new IdentityRole("Admin"));
            await roleManager.CreateAsync(new IdentityRole("User"));
            await roleManager.CreateAsync(new IdentityRole("Supervisor"));
        }

        private static async Task InitUsersAsync(UserManager<IdentityUser> userManager)
        {
            var user = new IdentityUser
            {
                UserName = "admin@website.com",
                Email = "admin@website.com",
                PhoneNumber = "123456789"
            };
            await userManager.CreateAsync(user, "waP6KEfz%NJtTpvt");
            await userManager.AddToRoleAsync(user, "Admin");
        }

        public static Int64 ToUnixEpochDate(this DateTime dateTime)
        {
            var result = (Int64)Math.Round((dateTime.ToUniversalTime() - new DateTimeOffset(1970, 1, 1, 0, 0, 0, TimeSpan.Zero)).TotalSeconds);

            return result;
        }
    }
}
