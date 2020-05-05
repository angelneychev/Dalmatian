namespace Dalmatian.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Dalmatian.Data.Models;
    using Microsoft.EntityFrameworkCore.Internal;

    public class ClubRegisterNumberSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.ClubRegisterNumbers.Any())
            {
                return;
            }

            var clubRegisterNumbers =
                new List<(int DogId, string ClubNumber)>
                {
                    (1,""),
                    (2,""),
                    (3,"10183"),
                    (4,"10184"),
                    (5,"10185"),
                    (6,"10186"),
                    (7,"10187"),
                    (8,"10188"),
                    (9,"10189"),
                    (10,"10190"),
                    (11,"10191"),
                    (12,"10192"),
                    (13,"10193"),
                    (14,""),
                    (15,"10176"),
                    (16,"10177"),
                    (17,"10178"),
                    (18,"10179"),
                    (19,"10180"),
                    (20,"10181"),
                    (21,"N 16826/08"),
                    (22,"10251"),
                    (23,""),
                    (24,"10220"),
                    (25,"10219"),
                    (26,"10275"),
                    (27,"10274"),
                    (28,"10273"),
                    (29,"10272"),
                    (30,"10271"),
                    (31,"10270"),
                    (32,"10269"),
                    (33,"10268"),
                    (34,"10250"),
                    (35,"10249"),
                    (36,"10248"),
                    (37,"10247"),
                    (38,"10246"),
                    (39,"10245"),
                    (40,"10244"),
                    (41,"10243"),
                    (42,"10242"),

                };
            foreach (var number in clubRegisterNumbers)
            {
                await dbContext.ClubRegisterNumbers.AddAsync(new ClubRegisterNumber
                {
                    DogId = number.DogId,
                    ClubNumber = number.ClubNumber,
                });
                await dbContext.SaveChangesAsync();
            }
        }
    }
}
