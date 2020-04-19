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
                ("Cm", 58.0f, "Kg", 27.0f, "Intact", "RS", "BG", 5),
                ("Cm", 58.0f, "Kg", 27.0f, "Intact", "RS", "BG", 6),
                ("Cm", 58.0f, "Kg", 27.0f, "Intact", "RS", "BG", 7),
                ("Cm", 58.0f, "Kg", 27.0f, "Intact", "RS", "BG", 8),
                ("Cm", 58.0f, "Kg", 27.0f, "Intact", "RS", "BG", 9),
                ("Cm", 58.0f, "Kg", 27.0f, "Intact", "RS", "BG", 10),
                ("Cm", 58.0f, "Kg", 27.0f, "Intact", "RS", "BG", 11),
                ("Cm", 58.0f, "Kg", 27.0f, "Intact", "RS", "BG", 12),
                ("Cm", 58.0f, "Kg", 27.0f, "Intact", "RS", "BG", 13),
                ("Cm", 58.0f, "Kg", 27.0f, "Intact", "RS", "BG", 14),
                ("Cm", 58.0f, "Kg", 27.0f, "Intact", "RS", "BG", 15),
                ("Cm", 58.0f, "Kg", 27.0f, "Intact", "RS", "BG", 16),
                ("Cm", 58.0f, "Kg", 27.0f, "Intact", "RS", "BG", 17),
                ("Cm", 58.0f, "Kg", 27.0f, "Intact", "RS", "BG", 18),
                ("Cm", 58.0f, "Kg", 27.0f, "Intact", "RS", "BG", 19),
                ("Cm", 58.0f, "Kg", 27.0f, "Intact", "RS", "BG", 20),
                ("Cm", 58.0f, "Kg", 27.0f, "Intact", "RS", "BG", 21),
                ("Cm", 58.0f, "Kg", 27.0f, "Intact", "RS", "BG", 22),
                ("Cm", 58.0f, "Kg", 27.0f, "Intact", "RS", "BG", 23),
                ("Cm", 58.0f, "Kg", 27.0f, "Intact", "RS", "BG", 24),
                ("Cm", 58.0f, "Kg", 27.0f, "Intact", "RS", "BG", 25),
                ("Cm", 57.0f, "Kg", 27.0f, "Intact", "BG", "BG", 26),
                ("Cm", 57.0f, "Kg", 27.0f, "Intact", "BG", "BG", 27),
                ("Cm", 57.0f, "Kg", 27.0f, "Intact", "BG", "BG", 28),
                ("Cm", 57.0f, "Kg", 27.0f, "Intact", "BG", "BG", 29),
                ("Cm", 62.5f, "Kg", 34.0f, "Intact", "CZ", "BG", 30),
                ("Cm", 62.5f, "Kg", 34.0f, "Intact", "CZ", "BG", 31),
                ("Cm", 62.5f, "Kg", 34.0f, "Intact", "CZ", "BG", 32),
                ("Cm", 62.5f, "Kg", 34.0f, "Intact", "CZ", "BG", 33),
                ("Cm", 62.5f, "Kg", 34.0f, "Intact", "CZ", "BG", 34),
                ("Cm", 62.5f, "Kg", 34.0f, "Intact", "CZ", "BG", 35),
                ("Cm", 62.5f, "Kg", 34.0f, "Intact", "CZ", "BG", 36),
                ("Cm", 62.5f, "Kg", 34.0f, "Intact", "CZ", "BG", 37),
                ("Cm", 62.5f, "Kg", 34.0f, "Intact", "CZ", "BG", 38),
                ("Cm", 62.5f, "Kg", 34.0f, "Intact", "CZ", "BG", 39),
                ("Cm", 62.5f, "Kg", 34.0f, "Intact", "CZ", "BG", 40),
                ("Cm", 58.0f, "Kg", 27.0f, "Intact", "RS", "BG", 41),
                ("Cm", 58.0f, "Kg", 27.0f, "Intact", "RS", "BG", 42),
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
                await dbContext.SaveChangesAsync();
            }
        }
    }
}