namespace Dalmatian.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Security.Cryptography.X509Certificates;
    using System.Threading.Tasks;

    using Dalmatian.Data.Models;
    using Dalmatian.Data.Models.Enum;
    using Microsoft.EntityFrameworkCore.Internal;

    public class DogSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Dogs.Any())
            {
                return;
            }

            await dbContext.Dogs.AddRangeAsync(new Dog
            {
                PedigreeName = "Perdita’s All My Tomorrows",
                Breed = Breed.Dalmatian,
                SexDog = SexDog.Male,
                Color = Color.WBRS,
                OwnerName = "Dimitar Ivanov",
            });
            await dbContext.Dogs.AddRangeAsync(new Dog
            {
                PedigreeName = "Spotmaniac Breath-taking View",
                Breed = Breed.Dalmatian,
                SexDog = SexDog.Female,
                Color = Color.WBRS,
                OwnerName = "Elena Neycheva",
            });
            await dbContext.Dogs.AddRangeAsync(new Dog
            {
                PedigreeName = "Bad & Mad Serbian Sensation in Raul",
                Breed = Breed.Dalmatian,
                SexDog = SexDog.Male,
                Color = Color.WBRS,
                OwnerName = "Elena Neychev",
            });
            await dbContext.Dogs.AddRangeAsync(new Dog
            {
                PedigreeName = "Bacardi Black by Mediolanum",
                Breed = Breed.Dalmatian,
                SexDog = SexDog.Female,
                Color = Color.WBRS,
                OwnerName = "Antonia Ivanova",
            });
        }
    }
}