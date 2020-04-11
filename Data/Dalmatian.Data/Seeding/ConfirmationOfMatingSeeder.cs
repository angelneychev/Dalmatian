namespace Dalmatian.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Dalmatian.Data.Models;
    using Dalmatian.Data.Models.Enum;
    using Microsoft.EntityFrameworkCore.Internal;

    public class ConfirmationOfMatingSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.ConfirmationOfMatings.Any())
            {
                return;
            }

            var clubRegisterNumbers =
                new List<(string RegistrationNumber,
                    int DogFatherId,
                    int DogMotherId,
                    string DateOfMating,
                    string EstimatedDateOfBirth,
                    string TypeOfMating)>
                {
                    ("000345/21-10", 1, 3, "2010-04-01 18:05:55", "2010-06-05 18:05:55", "NМ"),
                    ("000305/10-05", 2, 4, "2005-01-04 18:05:55", "2005-03-07 18:05:55", "NМ"),
                };

            foreach (var item in clubRegisterNumbers)
            {
                await dbContext.ConfirmationOfMatings.AddAsync(new ConfirmationOfMating()
                {
                    RegistrationNumber = item.RegistrationNumber,
                    DogFatherId = item.DogFatherId,
                    DogMotherId = item.DogMotherId,
                    DateOfMating = DateTime.Parse(item.DateOfMating),
                    EstimatedDateOfBirth = DateTime.Parse(item.EstimatedDateOfBirth),
                    TypeOfMating = Enum.Parse<TypeOfMating>(item.TypeOfMating),
                });
            }
        }
    }
}
