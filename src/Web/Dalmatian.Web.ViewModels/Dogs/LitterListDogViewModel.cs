namespace Dalmatian.Web.ViewModels.Dogs
{
    using System;
    using System.Collections.Generic;

    using Dalmatian.Data.Common.Models;
    using Dalmatian.Data.Models;
    using Dalmatian.Data.Models.Enum;
    using Dalmatian.Services.Mapping;

    public sealed class LitterListDogViewModel : BaseDeletableModel<int>, IMapFrom<Dog>
    {
        public string PedigreeName { get; set; }

        public int? FatherDogId { get; set; }

        public int? MotherDogId { get; set; }

        public Dog DogsDog { get; set; }

        public SexDog SexDog { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public DateTime? DateOfDeath { get; set; }

        public Color Color { get; set; }

        public int? PersonOwnerId { get; set; }

        public Person PersonOwner { get; set; }

        public int? PersonBreederId { get; set; }

        public Person PersonBreeder { get; set; }

        public string OffspringUrl => $"/club-dogs/{ this.PedigreeName.Replace(' ', '-') + "-" + this.Id}";

        public ICollection<Dog> SubFathers = new List<Dog>();

        public ICollection<Dog> SubMothers = new List<Dog>();

        public IEnumerable<ClubRegisterNumber> ClubRegisterNumbers { get; set; }

        public IEnumerable<RegistrationDogNumberViewModel> RegistrationDogNumbers { get; set; }
    }
}
