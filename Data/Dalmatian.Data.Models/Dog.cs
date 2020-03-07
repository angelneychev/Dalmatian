using System.Collections.Generic;
using System.Linq;

namespace Dalmatian.Data.Models
{
    using System;

    using Dalmatian.Data.Common.Models;
    using Dalmatian.Data.Models.Enum;

    public class Dog : BaseDeletableModel<int>
    {
        public Dog()
        {
            this.BreedingInformation = new HashSet<BreedingInformation>();
            this.DogHealthInformation = new HashSet<HealthInformation>();
            this.RegistrationDogNumbers = new HashSet<RegistrationDogNumber>();
            this.Parents = new HashSet<Parent>();
        }

        public string PedigreeName { get; set; }

        public Breed Breed { get; set; }

        public SexDog SexDog { get; set; }

        public Parent Parent { get; set; }

        //public int ParentId { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public DateTime? DateOfDeath { get; set; }

        public Color Color { get; set; }

        public string OwnerName { get; set; }

        public string BreederName { get; set; }

        public ClubRegisterNumber ClubRegisterNumber { get; set; }

        public int? ClubRegisterNumberId { get; set; }

        public virtual ICollection<Parent> Parents { get; set; }

        public virtual ICollection<BreedingInformation> BreedingInformation { get; set; }

        public virtual ICollection<HealthInformation> DogHealthInformation { get; set; }

        public virtual ICollection<RegistrationDogNumber> RegistrationDogNumbers { get; set; }
    }
}