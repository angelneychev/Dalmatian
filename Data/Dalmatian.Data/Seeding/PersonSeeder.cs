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
                ("Elena","Smrikarova", "Neychev", "elena@gmail", "0888000111", "http://spotmnaic.com", "BG", "Sofia", "Ivan Shishman 209", "http://facebook.com", "http://Twitter.com", "http://Instagram", "http://Linkedin"),
                ("Tania","", "Arangelova", "tanya@gmail", "0889000111", "http://dalmatian.net", "BG", "Plovdi", "kv. Levski bl. 205", "http://facebook.com", "http://Twitter.com", "http://Instagram", "http://Linkedin"),
                ("Aleksandra","Staikova", "Ivanova", "alex@gmail", "0888222111", "http://ivanka.net", "BG", "Sofia", "kv. Drujba bl. 405", "http://facebook.com", "http://Twitter.com", "http://Instagram", "http://Linkedin"),
                ("Ekaterina","", "Simeonova", "ekaterina@gmail", "0889333111", "http://petranka.net", "BG", "plovdiv", "ul. Praga bl. 205", "http://facebook.com", "http://Twitter.com", "http://Instagram", "http://Linkedin"),
                ("Ivan_1","Ivanov_1","Ivanov_1","Ivan_1@mail.com","0888000001","http://website1.com","BG","Grad1","Adres1","http://facebook.com","http://Twitter.com","http://Instagram","http://Linkedin"),
                ("Ivan_2","Ivanov_2","Ivanov_2","Ivan_2@mail.com","0888000002","http://website2.com","BG","Grad2","Adres2","http://facebook.com","http://Twitter.com","http://Instagram","http://Linkedin"),
                ("Ivan_3","Ivanov_3","Ivanov_3","Ivan_3@mail.com","0888000003","http://website3.com","BG","Grad3","Adres3","http://facebook.com","http://Twitter.com","http://Instagram","http://Linkedin"),
                ("Ivan_4","Ivanov_4","Ivanov_4","Ivan_4@mail.com","0888000004","http://website4.com","BG","Grad4","Adres4","http://facebook.com","http://Twitter.com","http://Instagram","http://Linkedin"),
                ("Ivan_5","Ivanov_5","Ivanov_5","Ivan_5@mail.com","0888000005","http://website5.com","BG","Grad5","Adres5","http://facebook.com","http://Twitter.com","http://Instagram","http://Linkedin"),
                ("Ivan_6","Ivanov_6","Ivanov_6","Ivan_6@mail.com","0888000006","http://website6.com","BG","Grad6","Adres6","http://facebook.com","http://Twitter.com","http://Instagram","http://Linkedin"),
                ("Ivan_7","Ivanov_7","Ivanov_7","Ivan_7@mail.com","0888000007","http://website7.com","BG","Grad7","Adres7","http://facebook.com","http://Twitter.com","http://Instagram","http://Linkedin"),
                ("Ivan_8","Ivanov_8","Ivanov_8","Ivan_8@mail.com","0888000008","http://website8.com","BG","Grad8","Adres8","http://facebook.com","http://Twitter.com","http://Instagram","http://Linkedin"),
                ("Ivan_9","Ivanov_9","Ivanov_9","Ivan_9@mail.com","0888000009","http://website9.com","BG","Grad9","Adres9","http://facebook.com","http://Twitter.com","http://Instagram","http://Linkedin"),
                ("Ivan_10","Ivanov_10","Ivanov_10","Ivan_10@mail.com","0888000010","http://website10.com","BG","Grad10","Adres10","http://facebook.com","http://Twitter.com","http://Instagram","http://Linkedin"),
                ("Ivan_11","Ivanov_11","Ivanov_11","Ivan_11@mail.com","0888000011","http://website11.com","BG","Grad11","Adres11","http://facebook.com","http://Twitter.com","http://Instagram","http://Linkedin"),
                ("Ivan_12","Ivanov_12","Ivanov_12","Ivan_12@mail.com","0888000012","http://website12.com","BG","Grad12","Adres12","http://facebook.com","http://Twitter.com","http://Instagram","http://Linkedin"),
                ("Ivan_13","Ivanov_13","Ivanov_13","Ivan_13@mail.com","0888000013","http://website13.com","BG","Grad13","Adres13","http://facebook.com","http://Twitter.com","http://Instagram","http://Linkedin"),
                ("Ivan_14","Ivanov_14","Ivanov_14","Ivan_14@mail.com","0888000014","http://website14.com","BG","Grad14","Adres14","http://facebook.com","http://Twitter.com","http://Instagram","http://Linkedin"),
                ("Ivan_15","Ivanov_15","Ivanov_15","Ivan_15@mail.com","0888000015","http://website15.com","BG","Grad15","Adres15","http://facebook.com","http://Twitter.com","http://Instagram","http://Linkedin"),
                ("Ivan_16","Ivanov_16","Ivanov_16","Ivan_16@mail.com","0888000016","http://website16.com","BG","Grad16","Adres16","http://facebook.com","http://Twitter.com","http://Instagram","http://Linkedin"),
                ("Ivan_17","Ivanov_17","Ivanov_17","Ivan_17@mail.com","0888000017","http://website17.com","BG","Grad17","Adres17","http://facebook.com","http://Twitter.com","http://Instagram","http://Linkedin"),
                ("Ivan_18","Ivanov_18","Ivanov_18","Ivan_18@mail.com","0888000018","http://website18.com","BG","Grad18","Adres18","http://facebook.com","http://Twitter.com","http://Instagram","http://Linkedin"),
                ("Ivan_19","Ivanov_19","Ivanov_19","Ivan_19@mail.com","0888000019","http://website19.com","BG","Grad19","Adres19","http://facebook.com","http://Twitter.com","http://Instagram","http://Linkedin"),
                ("Ivan_20","Ivanov_20","Ivanov_20","Ivan_20@mail.com","0888000020","http://website20.com","BG","Grad20","Adres20","http://facebook.com","http://Twitter.com","http://Instagram","http://Linkedin"),
                ("Maria_1","Petova_1","Georgieva_1","Maria_1@mail.com","0888000021","http://website21.com","BG","Grad1","Adres1","http://facebook.com","http://Twitter.com","http://Instagram","http://Linkedin"),
                ("Maria_2","Petova_2","Georgieva_2","Maria_2@mail.com","0888000022","http://website22.com","BG","Grad2","Adres2","http://facebook.com","http://Twitter.com","http://Instagram","http://Linkedin"),
                ("Maria_3","Petova_3","Georgieva_3","Maria_3@mail.com","0888000023","http://website23.com","BG","Grad3","Adres3","http://facebook.com","http://Twitter.com","http://Instagram","http://Linkedin"),
                ("Maria_4","Petova_4","Georgieva_4","Maria_4@mail.com","0888000024","http://website24.com","BG","Grad4","Adres4","http://facebook.com","http://Twitter.com","http://Instagram","http://Linkedin"),
                ("Maria_5","Petova_5","Georgieva_5","Maria_5@mail.com","0888000025","http://website25.com","BG","Grad5","Adres5","http://facebook.com","http://Twitter.com","http://Instagram","http://Linkedin"),
                ("Maria_6","Petova_6","Georgieva_6","Maria_6@mail.com","0888000026","http://website26.com","BG","Grad6","Adres6","http://facebook.com","http://Twitter.com","http://Instagram","http://Linkedin"),
                ("Maria_7","Petova_7","Georgieva_7","Maria_7@mail.com","0888000027","http://website27.com","BG","Grad7","Adres7","http://facebook.com","http://Twitter.com","http://Instagram","http://Linkedin"),
                ("Maria_8","Petova_8","Georgieva_8","Maria_8@mail.com","0888000028","http://website28.com","BG","Grad8","Adres8","http://facebook.com","http://Twitter.com","http://Instagram","http://Linkedin"),
                ("Maria_9","Petova_9","Georgieva_9","Maria_9@mail.com","0888000029","http://website29.com","BG","Grad9","Adres9","http://facebook.com","http://Twitter.com","http://Instagram","http://Linkedin"),
                ("Maria_10","Petova_10","Georgieva_10","Maria_10@mail.com","0888000030","http://website30.com","BG","Grad10","Adres10","http://facebook.com","http://Twitter.com","http://Instagram","http://Linkedin"),
                ("Maria_11","Petova_11","Georgieva_11","Maria_11@mail.com","0888000031","http://website31.com","BG","Grad11","Adres11","http://facebook.com","http://Twitter.com","http://Instagram","http://Linkedin"),
                ("Maria_12","Petova_12","Georgieva_12","Maria_12@mail.com","0888000032","http://website32.com","BG","Grad12","Adres12","http://facebook.com","http://Twitter.com","http://Instagram","http://Linkedin"),
                ("Maria_13","Petova_13","Georgieva_13","Maria_13@mail.com","0888000033","http://website33.com","BG","Grad13","Adres13","http://facebook.com","http://Twitter.com","http://Instagram","http://Linkedin"),
                ("Maria_14","Petova_14","Georgieva_14","Maria_14@mail.com","0888000034","http://website34.com","BG","Grad14","Adres14","http://facebook.com","http://Twitter.com","http://Instagram","http://Linkedin"),
                ("Maria_15","Petova_15","Georgieva_15","Maria_15@mail.com","0888000035","http://website35.com","BG","Grad15","Adres15","http://facebook.com","http://Twitter.com","http://Instagram","http://Linkedin"),
                ("Maria_16","Petova_16","Georgieva_16","Maria_16@mail.com","0888000036","http://website36.com","BG","Grad16","Adres16","http://facebook.com","http://Twitter.com","http://Instagram","http://Linkedin"),
                ("Maria_17","Petova_17","Georgieva_17","Maria_17@mail.com","0888000037","http://website37.com","BG","Grad17","Adres17","http://facebook.com","http://Twitter.com","http://Instagram","http://Linkedin"),
                ("Maria_18","Petova_18","Georgieva_18","Maria_18@mail.com","0888000038","http://website38.com","BG","Grad18","Adres18","http://facebook.com","http://Twitter.com","http://Instagram","http://Linkedin"),
                ("Maria_19","Petova_19","Georgieva_19","Maria_19@mail.com","0888000039","http://website39.com","BG","Grad19","Adres19","http://facebook.com","http://Twitter.com","http://Instagram","http://Linkedin"),
                ("Maria_20","Petova_20","Georgieva_20","Maria_20@mail.com","0888000040","http://website40.com","BG","Grad20","Adres20","http://facebook.com","http://Twitter.com","http://Instagram","http://Linkedin"),
                ("Maria_21","Petova_21","Georgieva_21","Maria_21@mail.com","0888000041","http://website41.com","BG","Grad20","Adres20","http://facebook.com","http://Twitter.com","http://Instagram","http://Linkedin"),

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
                await dbContext.SaveChangesAsync();
            }
        }
    }
}