namespace Dalmatian.Data.Seeding
{
    using System;
    using System.Collections.Generic;
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
                    (1,"PK 02482/03"),
                    (2,"PK 02324/02"),
                    (3,"PK 05687/06"),
                    (4,"PK 05688/06"),
                    (5,"PK 05689/06"),
                    (6,"PK 05690/06"),
                    (7,"PK 05691/06"),
                    (8,"PK 05692/06"),
                    (9,"PK 05693/06"),
                    (10,"PK 05694/06"),
                    (11,"PK 05695/06"),
                    (12,"PK 05696/06"),
                    (13,"PK 05697/06"),
                    (14,"PK 03365/04"),
                    (15,"PK 04699/05"),
                    (16,"PK 04700/05"),
                    (17,"PK 04701/05"),
                    (18,"PK 04702/05"),
                    (19,"PK 04703/05"),
                    (20,"PK 04704/05"),
                    (21,"PK 10705/08"),
                    (22,"PK 16290/11"),
                    (23,"PK 03567/04"),
                    (24,"РК 13256/09"),
                    (25,"РК 13255/09"),
                    (26,"РК 25171/14"),
                    (27,"РК 25170/14"),
                    (28,"РК 25169/14"),
                    (29,"РК 25168/14"),
                    (30,"РК 25167/14"),
                    (31,"РК 25166/14"),
                    (32,"РК 25165/14"),
                    (33,"РК 25164/14"),
                    (34,"PK 14776/10"),
                    (35,"PK 14775/10"),
                    (36,"PK 14774/10"),
                    (37,"PK 14773/10"),
                    (38,"PK 14772/10"),
                    (39,"PK 14771/10"),
                    (40,"PK 14770/10"),
                    (41,"PK 14769/10"),
                    (42,"PK 14768/10"),
                };

            foreach (var dog in dogs)
            {
                await dbContext.RegistrationDogNumbers.AddRangeAsync(new RegistrationDogNumber
                {
                    DogId = dog.DogId,
                    RegistrationNumber = dog.RegistrationNumber,
                });
            }
        }
    }
}
