namespace Dalmatian.Data.Seeding
{
    using System;
    using System.Threading.Tasks;

    using Dalmatian.Data.Models;
    using Microsoft.EntityFrameworkCore.Internal;

    public class ParentSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Parents.Any())
            {
                return;
            }

            await dbContext.Parents.AddAsync(new Parent
            {
                DogId = 2,
                FatherDogId = 3,
                MotherDogId = 4,
            });
        }
    }
}