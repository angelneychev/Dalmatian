namespace Dalmatian.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Dalmatian.Data.Models;
    using Dalmatian.Data.Models.Enum;
    using Microsoft.EntityFrameworkCore.Internal;

    public class PersonSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Persons.Any())
            {
                return;
            }

            var persons = new List<(string Firstname, string Middlename, string Lastname,
                string Email, string Phone, string Website, string Country, string City, string Address, string Facebook, 
                string Twitter, string Instagram, string Linkedin)>
            {
                ("Ivan","Ivanov", "Ivanov", "ivan@gmail", "0888000111", "http://dalmatian.com", "BG", "Sofia", "Ivan Shishman 209", "http://facebook.com", "http://Twitter.com", "http://Instagram", "http://Linkedin"),
                ("Elena","Petrova", "Georgieva", "elena@gmail", "0889000111", "http://dalmatian.net", "BG", "Varna", "kv. Levski bl. 205", "http://facebook.com", "http://Twitter.com", "http://Instagram", "http://Linkedin"),
                ("Ivanka","Petrova", "Hristova", "Ivanka@gmail", "0888222111", "http://ivanka.net", "BG", "Dobrich", "kv. Drujba bl. 405", "http://facebook.com", "http://Twitter.com", "http://Instagram", "http://Linkedin"),
                ("Petranka","Petrova", "Petrova", "Petranka@gmail", "0889333111", "http://petranka.net", "BG", "Plodviv", "ul. Praga bl. 205", "http://facebook.com", "http://Twitter.com", "http://Instagram", "http://Linkedin"),
            };

            foreach (var person in persons)
            {
                await dbContext.Persons.AddRangeAsync(new Person
                {
                    Firstname = person.Firstname,
                    Lastname = person.Lastname,
                    Middlename = person.Middlename,
                    Email = person.Email,
                    Phone = person.Phone,
                    Website = person.Website,
                    Country = Enum.Parse<Country>(person.Country),
                    City = person.City,
                    Address = person.Address,
                    Facebook = person.Facebook,
                    Twitter = person.Twitter,
                    Instagram = person.Instagram,
                    Linkedin = person.Linkedin,
                });
            }
        }
    }
}