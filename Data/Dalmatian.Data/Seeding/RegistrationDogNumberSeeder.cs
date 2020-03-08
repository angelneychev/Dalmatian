﻿using System.Collections.Generic;

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

            var dogs =
                new List<(int DogId, string RegistrationNumber)>
                {
                    (1, "PK10705/09"),
                    (2, "PK05697/06"),
                    (3, "PK02842/03"),
                    (4, "PK 02324/02"),
                };

            foreach (var dog in dogs)
            {

                await dbContext.RegistrationDogNumbers.AddRangeAsync(new RegistrationDogNumber
                {
                    DogId = dog.DogId,
                    RegistrationNumber = dog.RegistrationNumber,
                });
            }

            //await dbContext.RegistrationDogNumbers.AddRangeAsync(new RegistrationDogNumber
            //{
            //    DogId = 1,
            //    RegistrationNumber = "PK10705/09",
            //});

            //await dbContext.RegistrationDogNumbers.AddRangeAsync(new RegistrationDogNumber
            //{
            //    DogId = 2,
            //    RegistrationNumber = "PK05697/06",
            //});

            //await dbContext.RegistrationDogNumbers.AddRangeAsync(new RegistrationDogNumber
            //{
            //    DogId = 3,
            //    RegistrationNumber = "PK02842/03",
            //});

            //await dbContext.RegistrationDogNumbers.AddRangeAsync(new RegistrationDogNumber
            //{
            //    DogId = 4,
            //    RegistrationNumber = "PK 02324/02",
            //});
        }
    }
}