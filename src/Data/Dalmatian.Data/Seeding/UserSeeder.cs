namespace Dalmatian.Data.Seeding
{
    using System;
    using System.Threading.Tasks;

    using Dalmatian.Common;
    using Dalmatian.Data.Models;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore.Internal;
    using Microsoft.Extensions.DependencyInjection;

    public class UserSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            if (dbContext.Users.Any())
            {
                return;
            }

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

            var userClubMember = new ApplicationUser()
            {
                UserName = "elena@gmail.com",
                Email = "elena@gmail.com",
                EmailConfirmed = true,
            };

            string passwordClubMember = "123456";

            var resultClubMember = await userManager.CreateAsync(userClubMember, passwordClubMember);

            if (resultClubMember.Succeeded)
            {
                await userManager.AddToRoleAsync(userClubMember, GlobalConstants.ClubMemberRoleName);
            }

            var user = new ApplicationUser()
            {
                UserName = "user@gmail.com",
                Email = "user@gmail.com",
                EmailConfirmed = true,
            };

            string password = "123456";

            var resultUser = await userManager.CreateAsync(user, password);

            if (resultClubMember.Succeeded)
            {
                await userManager.AddToRoleAsync(user, GlobalConstants.UserRoleName);
            }
        }
    }
}
