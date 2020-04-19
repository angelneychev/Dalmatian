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
                ("Spotmanic","01215/02", "2000-04-05 18:05:55","BG", "ivan@gmail", "Sofia", 1),
                ("Divalinor","01815/00", "2001-07-05 18:05:55","BG", "maria@gmail", "Varna", 2),
                ("Dalmagic","01932/04", "2004-02-05 18:05:55","BG", "ivan@gmail", "Sofia", 3),
                ("Just Coffee","020132/06", "2006-06-05 18:05:55","BG", "ekaterina@gmail", "Plovdiv", 4),
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
                await dbContext.SaveChangesAsync();
            }
        }
    }
}