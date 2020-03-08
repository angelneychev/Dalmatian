namespace Dalmatian.Web.ViewModels.Dogs
{
    using System;

    using Dalmatian.Data.Models;
    using Dalmatian.Data.Models.Enum;
    using Dalmatian.Services.Mapping;

    public class DogInfoViewModel : IMapFrom<Dog>
    {
        public int Id { get; set; }

        public string PedigreeName { get; set; }

        public Breed Breed { get; set; }

        public SexDog SexDog { get; set; }

        public Parent Parent { get; set; }

        public string ImagesUrl { get; set; }

        public DateTime DateOfBirth { get; set; }

        public DateTime DateOfDeath { get; set; }

        public Color Color { get; set; }

        public string OwnerName { get; set; }

        public string BreederName { get; set; }
    }
}
