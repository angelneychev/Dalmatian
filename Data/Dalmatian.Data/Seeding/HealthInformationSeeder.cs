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
                    (1,"Bilateral","FCI_A1"),
                    (2,"Bilateral","FCI_A1"),
                    (3,"Bilateral","FCI_A1"),
                    (4,"Bilateral","FCI_A1"),
                    (5,"Bilateral","FCI_A1"),
                    (6,"Bilateral","FCI_A1"),
                    (7,"Bilateral","FCI_A1"),
                    (8,"Bilateral","FCI_A1"),
                    (9,"Bilateral","FCI_A1"),
                    (10,"Bilateral","FCI_A1"),
                    (11,"Bilateral","FCI_A1"),
                    (12,"Bilateral","FCI_A1"),
                    (13,"Bilateral","FCI_A1"),
                    (14,"Bilateral","FCI_A1"),
                    (15,"Bilateral","FCI_A1"),
                    (16,"Bilateral","FCI_A1"),
                    (17,"Bilateral","FCI_A1"),
                    (18,"Bilateral","FCI_A1"),
                    (19,"Bilateral","FCI_A1"),
                    (20,"Bilateral","FCI_A1"),
                    (21,"Bilateral","FCI_A1"),
                    (22,"Bilateral","FCI_A1"),
                    (23,"Bilateral","FCI_A1"),
                    (24,"Bilateral","FCI_A1"),
                    (25,"Bilateral","FCI_A1"),
                    (26,"Bilateral","FCI_A1"),
                    (27,"Bilateral","FCI_A1"),
                    (28,"Bilateral","FCI_A1"),
                    (29,"Bilateral","FCI_A1"),
                    (30,"Bilateral","FCI_A1"),
                    (31,"Bilateral","FCI_A1"),
                    (32,"Bilateral","FCI_A1"),
                    (33,"Bilateral","FCI_A1"),
                    (34,"Bilateral","FCI_A1"),
                    (35,"Bilateral","FCI_A1"),
                    (36,"Bilateral","FCI_A1"),
                    (37,"Bilateral","FCI_A1"),
                    (38,"Bilateral","FCI_A1"),
                    (39,"Bilateral","FCI_A1"),
                    (40,"Bilateral","FCI_A1"),
                    (41,"Bilateral","FCI_A1"),
                    (42,"Bilateral","FCI_A1"),

                };

            foreach (var dog in healthInformations)
            {
                await dbContext.HealthInformations.AddRangeAsync(new HealthInformation
                {
                    Baer = Enum.Parse<Baer>(dog.Baer),
                    HipRating = Enum.Parse<HipRating>(dog.HipRating),
                    DogId = dog.DogId,
                });
                await dbContext.SaveChangesAsync();
            }
        }
    }
}