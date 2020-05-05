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
#pragma warning disable EF1001 // Internal EF Core API usage.
            if (dbContext.BirthCertificates.Any())
#pragma warning restore EF1001 // Internal EF Core API usage.
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
                    ("100100/2005-01", "2005-05-17 00:00:00", 1, 5, 2, 3, 2, 2,"C"),
                    ("100102/2006-01", "2006-03-11 00:00:00", 2, 11, 9, 2, 1, 1, "B"),
                    ("100115/2009-07", "2009-09-12 00:00:00", 3, 2, 0, 2, 3, 3, "A"),
                    ("100130/2010-04", "2010-06-28 00:00:00", 4, 9, 4, 5, 1, 1, "C"),
                    ("100150/2014-14", "2014-03-29 00:00:00", 5, 1, 1, 1, 4, 4, "A"),
                    ("100150/2014-14", "2014-03-29 00:00:00", 6, 10, 5, 5, 3, 3, "B"),
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
                await dbContext.SaveChangesAsync();
            }
        }
    }
}