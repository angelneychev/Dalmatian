namespace Dalmatian.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Dalmatian.Data.Models;
    using Microsoft.EntityFrameworkCore.Internal;

    public class ParentSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            //if (dbContext.Parents.Any())
            //{
            //    return;
            //}

            //var parents = new List<(int DogId, int FatherDogId, int MotherDogId)>
            //{
            //    (2, 3, 4),
            //};

            //foreach (var parent in parents)
            //{
            //    await dbContext.Parents.AddAsync(new Parent
            //    {
            //        DogId = parent.DogId,
            //        FatherDogId = parent.FatherDogId,
            //        MotherDogId = parent.MotherDogId,
            //    });
            //}
        }
    }
}