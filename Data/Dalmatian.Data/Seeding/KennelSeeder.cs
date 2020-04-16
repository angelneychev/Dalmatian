namespace Dalmatian.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Dalmatian.Data.Models;
    using Dalmatian.Data.Models.Enum;
    using Microsoft.EntityFrameworkCore.Internal;

    public class KennelSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Kennels.Any())
            {
                return;
            }

            var kennels = new List<(string Name, string RegistrationNumber, string DateOfRegistration,
                string Country, string City, string Address, int PersonOwnerId)>
            {
                ("Spotmaniac","01215/02", "2000-04-05 18:05:55","BG", "ivan@gmail", "Sofia", 2),
                ("Divalinor","01815/00", "2001-04-05 18:05:55","BG", "ivan@gmail", "Plovdiv", 1),
            };

            foreach (var kennel in kennels)
            {
                await dbContext.Kennels.AddRangeAsync(new Kennel
                {
                    Name = kennel.Name,
                    RegistrationNumber = kennel.RegistrationNumber,
                    DateOfRegistration = DateTime.Parse(kennel.DateOfRegistration),
                    Country = Enum.Parse<Country>(kennel.Country),
                    City = kennel.City,
                    Address = kennel.Address,
                    PersonOwnerId = kennel.PersonOwnerId,
                });
            }
        }
    }
}