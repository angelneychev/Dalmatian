using System.Linq;

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
                new List<(string PedigreeName, string DateOfBirth, string DateOfDeath, string Breed, string SexDog, string Color, string FatherDogId, string MotherDogId, string PersonOwnerId, string PersonBreederId, string ImageUrl)>
                {
//("Bad & Mad Serbian Sensation in Raul","2002-09-28",string.Empty,"Dalmatian","Male","WBBS",string.Empty,string.Empty,"1",string.Empty,string.Empty),
                    ("Bad & Mad Serbian Sensation in Raul", "2002-09-28", "2010-11-21", "Dalmatian", "Male", "WBBS",
                        string.Empty, string.Empty, "1", string.Empty,
                        "https://upload.wikimedia.org/wikipedia/commons/2/21/Bad_%26_Mad_Serbian_Sensation_in_Raul.jpg"),
                    ("Bacardi Black by Mediolanum", "2002-05-20", "2019-08-16", "Dalmatian", "Female", "WBBS",
                        string.Empty, string.Empty, "5", string.Empty, "http://spotmaniac.com/images/ayra6m.jpg"),
                    ("Spotmaniac Big Babbler", "2006-03-11", "2016-03-02", "Dalmatian", "Male", "WBBS", "1", "2", "7",
                        "1", "https://spotmaniac.com/gallery/albums/userpics/10001/spotmaniac%20big%20babbler.jpg"),
                    ("Spotmaniac Blizzard", "2006-03-11", "2017-09-23", "Dalmatian", "Male", "WBBS", "1", "2", "8", "1",
                        "http://spotmaniac.com/gallery/albums/userpics/10001/Blizzard_52d_l.jpg"),
                    ("Spotmaniac Bee’s Knees", "2006-03-11", "2018-02-01", "Dalmatian", "Male", "WBBS", "1", "2", "9",
                        "1", "http://spotmaniac.com/gallery/albums/userpics/10001/Spotmaniac%20Bees%20Knees2.jpg"),
                    ("Spotmaniac Bright Man", "2006-03-11", "2019-07-21", "Dalmatian", "Male", "WBBS", "1", "2", "10",
                        "1", "http://spotmaniac.com/gallery/albums/userpics/10001/Spotmaniac_Bright_Man1.jpg"),
                    ("Spotmaniac Believable Regal", "2006-03-11", string.Empty, "Dalmatian", "Male", "WBBS", "1", "2",
                        "11", "1",
                        "http://spotmaniac.com/gallery/albums/userpics/10001/Spotmaniac_Believable_Regal~0.jpg"),
                    ("Spotmaniac Big Bang", "2006-03-11", string.Empty, "Dalmatian", "Male", "WBBS", "1", "2", "12",
                        "1", "http://spotmaniac.com/gallery/albums/userpics/10001/SPOTMANIAC%20BIG%20BANG-5monts.jpg"),
                    ("Spotmaniac Blackout Sun", "2006-03-11", string.Empty, "Dalmatian", "Male", "WBBS", "1", "2", "13",
                        "1", "http://spotmaniac.com/gallery/albums/userpics/10001/Balckout_Sun_37d_r.jpg"),
                    ("Spotmaniac Brown Sugar Dude", "2006-03-11", string.Empty, "Dalmatian", "Male", "WBBS", "1", "2",
                        "1", "1", "http://spotmaniac.com/gallery/albums/userpics/10001/tero.jpg"),
                    ("Spotmaniac Borimir", "2006-03-11", "2020-01-10", "Dalmatian", "Male", "WBLS", "1", "2", "14", "1",
                        "http://spotmaniac.com/gallery/albums/userpics/10001/Borimir_37d_l.jpg"),
                    ("Spotmaniac BG Joomla", "2006-03-11", "2018-09-20", "Dalmatian", "Female", "WBLS", "1", "2", "1",
                        "1", "http://spotmaniac.com/gallery/albums/userpics/10001/areta1.jpg"),
                    ("Spotmaniac  Breath taking View", "2006-03-11", "2019-08-20", "Dalmatian", "Female", "WBBS", "1",
                        "2", "1", "1", "http://spotmaniac.com/gallery/albums/userpics/10001/Erika_18_3m.jpg"),
                    ("Sweet Emotion Panthera Unica", "2003-04-30", "2015-06-07", "Dalmatian", "Female", "WBLS",
                        string.Empty, string.Empty, "2", string.Empty,
                        "https://www.pedigreedatabase.com/pictures/1871514-489794.jpg"),
                    ("Divalinor Cotton Cloud", "2005-05-17", string.Empty, "Dalmatian", "Male", "WBBS", "1", "14", "25",
                        "2", string.Empty),
                    ("Divalinor Count of Gold", "2005-05-17", "2019-08-08", "Dalmatian", "Male", "WBLS", "1", "14", "2",
                        "2",
                        "https://www.dalmatianbg.org/wp-content/uploads/2014/02/249162_524322610948605_875664558_n1.jpg"),
                    ("Divalinor Cool Night", "2005-05-17", string.Empty, "Dalmatian", "Female", "WBBS", "1", "14", "22",
                        "2", string.Empty),
                    ("Divalinor Cream Vanilla", "2005-05-17", "2015-11-24", "Dalmatian", "Female", "WBBS", "1", "14",
                        "1", "2", "https://spotmaniac.com/gallery/albums/userpics/10001/viki_7_okt_2006_1.jpg"),
                    ("Divalinor Class Edition", "2005-05-17", string.Empty, "Dalmatian", "Female", "WBBS", "1", "14",
                        "23", "2", string.Empty),
                    ("Divalinor Coffee Cake", "2005-05-17", string.Empty, "Dalmatian", "Female", "WBLS", "1", "14",
                        "18", "2", "http://www.dalmatianbg.org/wp-content/uploads/2014/07/divalinorcoffeecake.jpg"),
                    ("Perdita’s All My Tomorrows", "2008-06-13", "2018-09-20", "Dalmatian", "Male", "WBBS",
                        string.Empty, string.Empty, "25", string.Empty, "http://www.spotmaniac.com/images/andy81a.jpg"),
                    ("Just Coffee Amaranth Lake a Magic", "2011-02-11", string.Empty, "Dalmatian", "Male", "WBLS", "21",
                        "20", "1", "4",
                        "https://image.jimcdn.com/app/cms/image/transf/dimension=610x10000:format=jpg/path/s38165ba9fb8338c2/image/ifc697f2cfa926076/version/1424780644/image.jpg"),
                    ("Only You Darling Wonderdevil", "2004-02-04", "2017-12-10", "Dalmatian", "Female", "WBBS",
                        string.Empty, string.Empty, "26", string.Empty,
                        "http://www.dalmatianbg.org/wp-content/uploads/2014/07/pict0021-57-300x225.jpg"),
                    ("Dalmagic Ace of Cake", "2009-12-09", string.Empty, "Dalmatian", "Female", "WBBS", "16", "23", "3",
                        "3",
                        "https://www.dalmatianbg.org/wp-content/uploads/2014/02/401810_2155648347835_1403455533_n.jpg"),
                    ("Dalmagic Absolute Winner", "2009-12-09", string.Empty, "Dalmatian", "Female", "WBBS", "16", "23",
                        string.Empty, "3", string.Empty),
                    ("Dalmagic Back in Black", "2014-03-29", string.Empty, "Dalmatian", "Female", "WBLS", "22", "24",
                        "3", "3", "http://www.dalmagic.net/images/10641102_4638446616240_3997031198480660246_n.jpg"),
                    ("Dalmagic Bailey''s Coffee", "2014-03-29", string.Empty, "Dalmatian", "Female", "WBBS", "22", "24",
                        string.Empty, "3", string.Empty),
                    ("Dalmagic Bulgarian Girl", "2014-03-29", string.Empty, "Dalmatian", "Female", "WBBS", "22", "24",
                        string.Empty, "3", string.Empty),
                    ("Dalmagic Bumble Bee", "2014-03-29", string.Empty, "Dalmatian", "Male", "WBBS", "22", "24", "19",
                        "3", string.Empty),
                    ("Dalmagic Blazing Count of Gold", "2014-03-29", string.Empty, "Dalmatian", "Male", "WBBS", "22",
                        "24", "20", "3", string.Empty),
                    ("Dalmagic Brown Sweet Chocolate", "2014-03-29", string.Empty, "Dalmatian", "Male", "WBBS", "22",
                        "24", "21", "3", string.Empty),
                    ("Dalmagic Beasty Boy", "2014-03-29", string.Empty, "Dalmatian", "Male", "WBBS", "22", "24", "22",
                        "3", string.Empty),
                    ("Dalmagic Biker Boy", "2014-03-29", string.Empty, "Dalmatian", "Male", "WBBS", "22", "24", "23",
                        "3", string.Empty),
                    ("Spotmaniac Chain Reaction", "2010-06-28", string.Empty, "Dalmatian", "Female", "WBBS", "21", "13",
                        "32", "1",
                        "http://spotmaniac.com/gallery/albums/userpics/10001/normal_Spotmaniac_Chain_Reaction_l800.jpg"),
                    ("Spotmaniac Count’em All", "2010-06-28", string.Empty, "Dalmatian", "Female", "WBBS", "21", "13",
                        "29", "1",
                        "http://spotmaniac.com/gallery/albums/userpics/10001/normal_Spotmaniac_Count_em_All_34d_l800.jpg"),
                    ("Spotmaniac Coming Attraction", "2010-06-28", string.Empty, "Dalmatian", "Female", "WBBS", "21",
                        "13", "1", "1",
                        "http://spotmaniac.com/gallery/albums/userpics/10001/normal_Spotmaniac_Coming_Attraction_l800.jpg"),
                    ("Spotmaniac Close Connection", "2010-06-28", string.Empty, "Dalmatian", "Female", "WBBS", "21",
                        "13", "34", "1",
                        "http://spotmaniac.com/gallery/albums/userpics/10001/normal_Spotmaniac_Close_Connection_r800.jpg"),
                    ("Spotmaniac Colourful Magic", "2010-06-28", string.Empty, "Dalmatian", "Female", "WBBS", "21",
                        "13", "35", "1",
                        "http://spotmaniac.com/gallery/albums/userpics/10001/normal_Spotmaniac_Colourful_Magic_l800.jpg"),
                    ("Spotmaniac Carte Blanche", "2010-06-28", string.Empty, "Dalmatian", "Male", "WBBS", "21", "13",
                        "36", "1",
                        "http://spotmaniac.com/gallery/albums/userpics/10001/normal_Spotmaniac_Carte_Blanche_l800.jpg"),
                    ("Spotmaniac Copy for Tomorrow", "2010-06-28", string.Empty, "Dalmatian", "Male", "WBBS", "21",
                        "13", "37", "1",
                        "http://spotmaniac.com/gallery/albums/userpics/10001/normal_Spotmaniac_Copy_For_Tomorrow_r800.jpg"),
                    ("Spotmaniac Confident Challenger", "2010-06-28", string.Empty, "Dalmatian", "Male", "WBBS", "21",
                        "13", "38", "1",
                        "http://spotmaniac.com/gallery/albums/userpics/10001/normal_Spotmaniac_Confident_Challenger_l800.jpg"),
                    ("Spotmaniac Capo di Tutti Capi", "2010-06-28", string.Empty, "Dalmatian", "Male", "WBBS", "21",
                        "13", "39", "1",
                        "http://spotmaniac.com/gallery/albums/userpics/10001/normal_Spotmaniac_Capo_di_Tutti_Capi_l800.jpg"),

                };
            foreach (var dog in dogs)
            {
                await dbContext.Dogs.AddRangeAsync(new Dog
                {
                    PedigreeName = dog.PedigreeName,
                    DateOfBirth = string.IsNullOrEmpty(dog.DateOfBirth) ? (DateTime?)null : DateTime.Parse(dog.DateOfBirth),
                    DateOfDeath = string.IsNullOrEmpty(dog.DateOfDeath) ? (DateTime?)null : DateTime.Parse(dog.DateOfDeath),
                    Breed = Enum.Parse<Breed>(dog.Breed),
                    SexDog = Enum.Parse<SexDog>(dog.SexDog),
                    Color = Enum.Parse<Color>(dog.Color),
                    FatherDogId = string.IsNullOrEmpty(dog.FatherDogId) ? (int?)null : int.Parse(dog.FatherDogId),
                    MotherDogId = string.IsNullOrEmpty(dog.MotherDogId) ? (int?)null : int.Parse(dog.MotherDogId),
                    PersonOwnerId = string.IsNullOrEmpty(dog.PersonOwnerId) ? (int?)null : int.Parse(dog.PersonOwnerId),
                    PersonBreederId = string.IsNullOrEmpty(dog.PersonBreederId) ? (int?)null : int.Parse(dog.PersonBreederId),
                    ImagesUrl = dog.ImageUrl,
                });
                await dbContext.SaveChangesAsync();
            }
        }
    }
}
