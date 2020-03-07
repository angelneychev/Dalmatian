namespace Dalmatian.Data.Seeding
{
    using System;
    using System.Threading.Tasks;

    using Dalmatian.Data.Models;
    using Microsoft.EntityFrameworkCore.Internal;

    public class RegistrationDogNumberSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.RegistrationDogNumbers.Any())
            {
                return;
            }

            await dbContext.RegistrationDogNumbers.AddRangeAsync(new RegistrationDogNumber
            {
                DogId = 1,
                RegistrationNumber = "PK10705/09",
            });

            await dbContext.RegistrationDogNumbers.AddRangeAsync(new RegistrationDogNumber
            {
                DogId = 2,
                RegistrationNumber = "PK05697/06",
            });

            await dbContext.RegistrationDogNumbers.AddRangeAsync(new RegistrationDogNumber
            {
                DogId = 3,
                RegistrationNumber = "PK02842/03",
            });

            await dbContext.RegistrationDogNumbers.AddRangeAsync(new RegistrationDogNumber
            {
                DogId = 4,
                RegistrationNumber = "PK 02324/02",
            });
        }
    }
}