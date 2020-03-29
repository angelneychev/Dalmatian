namespace Dalmatian.Web.ViewModels.Dogs
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Dalmatian.Data.Models;
    using Dalmatian.Data.Models.Enum;
    using Dalmatian.Services.Mapping;

    public class DogsViewModel : IMapFrom<Dog>
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

        public string OwnerName { get; set; }

        public string BreederName { get; set; }

        public IEnumerable<ParentViewModel> Parents { get; set; }

        public IEnumerable<BreedingInformation> BreedingInformations { get; set; }

        public IEnumerable<ClubRegisterNumber> ClubRegisterNumbers { get; set; }

        public IEnumerable<HealthInformationViewModel> HealthInformations { get; set; }

        public IEnumerable<RegistrationDogNumberViewModel> RegistrationDogNumbers { get; set; }
    }
}
