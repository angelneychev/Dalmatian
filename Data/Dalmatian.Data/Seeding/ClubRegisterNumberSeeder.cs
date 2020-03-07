namespace Dalmatian.Data.Seeding
{
    using System;
    using System.Threading.Tasks;

    using Dalmatian.Data.Models;
    using Microsoft.EntityFrameworkCore.Internal;

    public class ClubRegisterNumberSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.ClubRegisterNumbers.Any())
            {
                return;
            }

            await dbContext.ClubRegisterNumbers.AddAsync(new ClubRegisterNumber
            {
                ClubNumber = "10193",
            });
        }
    }
}