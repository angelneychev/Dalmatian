namespace Dalmatian.Web.ViewModels.Dogs
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Dalmatian.Data.Models;
    using Dalmatian.Data.Models.Enum;
    using Dalmatian.Services.Mapping;

    public class DogSexViewMode : IMapFrom<Dog>, IMapTo<Dog>
    {
        public int Id { get; set; }

        public string PedigreeName { get; set; }

        public Breed Breed { get; set; }

        public SexDog SexDog { get; set; }

        public string ImagesUrl { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd MMM yyyy")]
        public DateTime? DateOfBirth { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd MMM yyyy")]
        public DateTime? DateOfDeath { get; set; }

        public Color Color { get; set; }

        public int? PersonOwnerId { get; set; }

        public Person PersonOwner { get; set; }

        public int? PersonBreederId { get; set; }

        public Person PersonBreeder { get; set; }

        public int? FatherDogId { get; set; }

        public Dog Father { get; set; }

        public int? MotherDogId { get; set; }

        public Dog Mother { get; set; }

        public string RedirectUrl => $"/club-dogs/{this.PedigreeName.Replace(' ', '-') + "-" + this.Id}";

        public IEnumerable<RegistrationDogNumberViewModel> RegistrationDogNumbers { get; set; }

        public IEnumerable<ClubRegisterNumber> ClubRegisterNumbers { get; set; }
    }
}
