using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Dalmatian.Data.Models;
using Dalmatian.Data.Models.Enum;
using Microsoft.EntityFrameworkCore.Internal;

namespace Dalmatian.Data.Seeding
{
    public class BreedingInformationSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.BreedingInformations.Any())
            {
                return;
            }

            var dogs = new List<(string HeightUnits, double Height, string WeightUnits, double Weight, string BreedingStatus, string CountryOfOrigin, string CountryOfResidence, int DogId)>
            {
                ("cm", 60.0f, "kg", 30.0f, "Intact", "NO", "BG", 1),
                ("cm", 57.0f, "kg", 27.0f, "Intact", "BG", "BG", 2),
                ("cm", 62.5f, "kg", 34.0f, "Intact", "CZ", "BG", 3),
                ("cm", 58.0f, "kg", 27.0f, "Intact", "RS", "BG", 4),
            };

            foreach (var dog in dogs)
            {
                await dbContext.BreedingInformations.AddRangeAsync(new BreedingInformation
                {
                    HeightUnits = Enum.Parse<HeightUnits>(dog.HeightUnits),
                    Height = dog.Height,
                    WeightUnits = Enum.Parse<WeightUnits>(dog.WeightUnits),
                    Weight = dog.Weight,
                    BreedingStatus = Enum.Parse<BreedingStatus>(dog.BreedingStatus),
                    CountryOfOrigin = Enum.Parse<Country>(dog.CountryOfOrigin),
                    CountryOfResidence = Enum.Parse<Country>(dog.CountryOfResidence),
                    DogId = dog.DogId,
                });
            }
        }
    }
}