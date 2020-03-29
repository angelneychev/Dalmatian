namespace Dalmatian.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Dalmatian.Data.Models;
    using Dalmatian.Data.Models.Enum;
    using Microsoft.EntityFrameworkCore.Internal;

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
                ("Cm", 60.0f, "Kg", 30.0f, "Intact", "NO", "BG", 1),
                ("Cm", 57.0f, "Kg", 27.0f, "Intact", "BG", "BG", 2),
                ("Cm", 62.5f, "Kg", 34.0f, "Intact", "CZ", "BG", 3),
                ("Cm", 58.0f, "Kg", 27.0f, "Intact", "RS", "BG", 4),
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