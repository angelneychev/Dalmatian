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

            var dogs =
                new List<(string PedigreeName, string Breed, string SexDog, string Color, int PersonOwnerId, string ImageUrl)>
                {
                    ("Perdita’s All My Tomorrows", "Dalmatian", "Male", "WBRS",1,
                        "https://plovdivshow.files.wordpress.com/2012/04/554278_353370938043774_961209239_n.jpg"),
                    ("Spotmaniac Breath taking View", "Dalmatian", "Female", "WBRS", 2,
                        "http://www.spotmaniac.com/images/Erika_CACIB_Vratza-Sofia.jpg"),
                    ("Bad & Mad Serbian Sensation in Raul", "Dalmatian", "Male", "WBRS", 2,
                        "https://upload.wikimedia.org/wikipedia/commons/2/21/Bad_%26_Mad_Serbian_Sensation_in_Raul.jpg"),
                    ("Bacardi Black by Mediolanum", "Dalmatian", "Female", "WBRS", 3,
                        "https://vishi-dalm.ucoz.ru/foto_pred/Ayra_22_m1.jpg"),

                };
            foreach (var dog in dogs)
            {
                await dbContext.Dogs.AddRangeAsync(new Dog
                {
                    PedigreeName = dog.PedigreeName,
                    Breed = Enum.Parse<Breed>(dog.Breed),
                    SexDog = Enum.Parse<SexDog>(dog.SexDog),
                    Color = Enum.Parse<Color>(dog.Color),
                    PersonOwnerId = dog.PersonOwnerId,
                    ImagesUrl = dog.ImageUrl,
                });
            }

            //await dbContext.Dogs.AddRangeAsync(new Dog
            //{
            //    PedigreeName = "Perdita’s All My Tomorrows",
            //    Breed = Breed.Dalmatian,
            //    SexDog = SexDog.Male,
            //    Color = Color.WBRS,
            //    OwnerName = "Dimitar Ivanov",
            //});
            //await dbContext.Dogs.AddRangeAsync(new Dog
            //{
            //    PedigreeName = "Spotmaniac Breath-taking View",
            //    Breed = Breed.Dalmatian,
            //    SexDog = SexDog.Female,
            //    Color = Color.WBRS,
            //    OwnerName = "Elena Neycheva",
            //});
            //await dbContext.Dogs.AddRangeAsync(new Dog
            //{
            //    PedigreeName = "Bad & Mad Serbian Sensation in Raul",
            //    Breed = Breed.Dalmatian,
            //    SexDog = SexDog.Male,
            //    Color = Color.WBRS,
            //    OwnerName = "Elena Neychev",
            //});
            //await dbContext.Dogs.AddRangeAsync(new Dog
            //{
            //    PedigreeName = "Bacardi Black by Mediolanum",
            //    Breed = Breed.Dalmatian,
            //    SexDog = SexDog.Female,
            //    Color = Color.WBRS,
            //    OwnerName = "Antonia Ivanova",
            //});
        }
    }
}
