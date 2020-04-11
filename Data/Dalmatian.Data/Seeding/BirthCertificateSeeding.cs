namespace Dalmatian.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Dalmatian.Data.Models;
    using Dalmatian.Data.Models.Enum;
    using Microsoft.EntityFrameworkCore.Internal;

    public class BirthCertificateSeeding : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.BirthCertificates.Any())
            {
                return;
            }

            var birthCertificates =
                new List<(string RegistrationNumber,
                    string DateOfBirth,
                    int ConfirmationOfMatingId,
                    int NumberOfPuppies,
                    int NumberOfMales,
                    int NumberOfFemales,
                    int PersonId,
                    int KennelId,
                    string LetterOfLitter)>
                {
                    ("100266/70-05", "2005-03-07 18:05:55", 1, 1, 0, 1, 1, 1, "C"),
                    ("100276/100-10","2010-06-05 18:05:55", 2, 3, 1, 2, 1, 1, "C"),
                };

            foreach (var item in birthCertificates)
            {
                await dbContext.BirthCertificates.AddAsync(new BirthCertificate()
                {
                    RegistrationNumber = item.RegistrationNumber,
                    DateOfBirth = DateTime.Parse(item.DateOfBirth),
                    ConfirmationOfMatingId = item.ConfirmationOfMatingId,
                    NumberOfPuppies = item.NumberOfPuppies,
                    NumberOfMales = item.NumberOfMales,
                    NumberOfFemales = item.NumberOfFemales,
                    PersonId = item.PersonId,
                    KennelId = item.KennelId,
                    LetterOfLitter = Enum.Parse<LetterOfLitter>(item.LetterOfLitter),
                });
            }
        }
    }
}