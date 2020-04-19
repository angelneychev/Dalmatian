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
                    ("000100/2005-01", 1, 14, "2005-03-12 18:05:55", "2005-05-18 00:00:00", "NМ"),
                    ("000102/2006-01", 1, 2, "2006-01-03 00:00:00", "2006-03-11 00:00:00", "NМ"),
                    ("000115/2009-07", 16, 23, "2009-07-03 00:00:00", "2009-09-12 00:00:00", "NМ"),
                    ("000130/2010-04", 16, 23, "2010-04-20 00:00:00", "2010-06-28 00:00:00", "NМ"),
                    ("000140/2011-02", 16, 23, "2010-12-28 00:00:00", "2011-02-11 00:00:00", "NМ"),
                    ("000150/2014-14", 16, 23, "2014-01-20 00:00:00", "2014-03-29 00:00:00", "NМ"),
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
