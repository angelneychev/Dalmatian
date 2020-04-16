namespace Dalmatian.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

    using Dalmatian.Data.Common.Models;
    using Dalmatian.Data.Models.Enum;

    public class Dog : BaseDeletableModel<int>
    {
        public Dog()
        {
            this.BreedingInformations = new HashSet<BreedingInformation>();
            this.HealthInformations = new HashSet<HealthInformation>();
            this.RegistrationDogNumbers = new HashSet<RegistrationDogNumber>();
            this.ClubRegisterNumbers = new HashSet<ClubRegisterNumber>();
        }

        [MaxLength(250)]
        public string PedigreeName { get; set; }

        public Breed Breed { get; set; }

        public SexDog SexDog { get; set; }

        public string ImagesUrl { get; set; }

        public DateTime? DateOfBirth { get; set; }

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

        public ICollection<Dog> SubFathers { get; set; }

        public ICollection<Dog> SubMothers { get; set; }

        public ICollection<ClubRegisterNumber> ClubRegisterNumbers { get; set; }

        public ICollection<BreedingInformation> BreedingInformations { get; set; }

        public ICollection<HealthInformation> HealthInformations { get; set; }

        public ICollection<RegistrationDogNumber> RegistrationDogNumbers { get; set; }


    }
}