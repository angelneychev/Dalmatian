namespace Dalmatian.Data.Seeding
{
    using System;
    using System.Collections.Generic;
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
            var clubRegisterNumbers =
                new List<(int DogId, string ClubNumber)>
                {
                    (1, "10193"),
                    (2, "10103"),
                    (3, "10203"),
                    (4, "10153"),
                };
            foreach (var number in clubRegisterNumbers)
            {
                await dbContext.ClubRegisterNumbers.AddAsync(new ClubRegisterNumber
                {
                    DogId = number.DogId,
                    ClubNumber = number.ClubNumber,
                });
            }
        }
    }
}
