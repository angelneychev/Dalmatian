namespace Dalmatian.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Dalmatian.Data.Models;
    using Dalmatian.Data.Models.Enum;
    using Microsoft.EntityFrameworkCore.Internal;

    public class HealthInformationSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.HealthInformations.Any())
            {
                return;
            }

            var healthInformations =
                new List<(int DogId, string Baer, string HipRating)>
                {
                    (1, "bilateral", "FCI_A1"),
                    (2, "bilateral", "FCI_A1"),
                    (3, "bilateral", "FCI_A1"),
                    (4, "bilateral", "FCI_A1"),
                };

            foreach (var dog in healthInformations)
            {
                await dbContext.HealthInformations.AddRangeAsync(new HealthInformation
                {
                    Baer = Enum.Parse<Baer>(dog.Baer),
                    HipRating = Enum.Parse<HipRating>(dog.HipRating),
                    DogId = dog.DogId,
                });
            }
        }
    }
}