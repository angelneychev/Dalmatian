namespace Dalmatian.Data.Seeding
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using Dalmatian.Common;
    using Dalmatian.Data.Models;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;

    internal class RolesSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<ApplicationRole>>();
            
            await SeedRoleAsync(roleManager, GlobalConstants.AdministratorRoleName);
            await SeedRoleAsync(roleManager, GlobalConstants.ClubMemberRoleName);
            await SeedRoleAsync(roleManager, GlobalConstants.UserRoleName);
        }

        private static async Task SeedRoleAsync(RoleManager<ApplicationRole> roleManager, string roleName)
        {
            var role = await roleManager.FindByNameAsync(roleName);
            if (role == null)
            {
                var result = await roleManager.CreateAsync(new ApplicationRole(roleName));
                if (!result.Succeeded)
                {
                    throw new Exception(string.Join(Environment.NewLine, result.Errors.Select(e => e.Description)));
                }
            }
        }

        private static async Task SeedRoleAsync(UserManager<ApplicationUser> userManager, string userName)
        {
            var userRole = await userManager.FindByNameAsync(userName);

            if (!userRole.UserName.Contains("admin@gmail.com"))
            {
                var adminUser = new ApplicationUser()
                {
                    UserName = "admin@gmail.com",
                    Email = "admin@gmail.com",
                    EmailConfirmed = true,
                };

                string passwordAdmin = "123456";

                var resultAdminUser = await userManager.CreateAsync(adminUser, passwordAdmin);

                if (resultAdminUser.Succeeded)
                {
                    await userManager.AddToRoleAsync(adminUser, GlobalConstants.AdministratorRoleName);
                }
            }
            if (!userRole.UserName.Contains("elena@gmail.com"))
            {
                var user = new ApplicationUser()
                {
                    UserName = "elena@gmail.com",
                    Email = "elena@gmail.com",
                    EmailConfirmed = true,
                };

                string password = "123456";

                var resultClubMember = await userManager.CreateAsync(user, password);

                if (resultClubMember.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, GlobalConstants.ClubMemberRoleName);
                }
            }

            if (!userRole.UserName.Contains("user@gmail.com"))
            {
                var user = new ApplicationUser()
                {
                    UserName = "user@gmail.com",
                    Email = "user@gmail.com",
                    EmailConfirmed = true,
                };

                string password = "123456";

                var resultClubMember = await userManager.CreateAsync(user, password);

                if (resultClubMember.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, GlobalConstants.UserRoleName);
                }
            }
        }
    }
}
