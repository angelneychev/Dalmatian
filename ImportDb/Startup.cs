using System;
using Dalmatian.Data;
using Dalmatian.Data.Models;
using Dalmatian.Data.Models.Enum;
using Microsoft.EntityFrameworkCore;

namespace ImportDb
{
    public class Startup
    {
        public static void Main()
        {
            using (var data = new ApplicationDbContext())
            {
                Dog dalmatian;
                dalmatian = new Dog
                {
                    PedigreeName = "Imemto na Dalmatina",
                    Breed = Enum.Parse<Breed>("Dalmatian"),
                    SexDog = Enum.Parse<SexDog>("male"),
                    Color = Enum.Parse<Color>("WBLS"),
                    OwnerName = "By Ivan",
                    BreederName = "By Petkan",
                };
                data.Dogs.Add(dalmatian);
                data.SaveChanges();

            }
        }

    }
}
