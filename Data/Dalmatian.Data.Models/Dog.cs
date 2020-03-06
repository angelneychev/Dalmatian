using System.Collections.Generic;
using System.Linq;

namespace Dalmatian.Data.Models
{
    using System;

    using Dalmatian.Data.Common.Models;
    using Dalmatian.Data.Models.Enum;

    public class Dog : BaseDeletableModel<int>
    {
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

        //public Person Person { get; set; }

        //public int? PersonId { get; set; }

        public ClubRegisterNumber ClubRegisterNumber { get; set; }

        public int? ClubRegisterNumberId { get; set; }

        //public virtual ICollection<Parent> DogParents { get; set; } = new HashSet<Parent>();

        public virtual ICollection<BreedingInformation> BreedingInformation { get; set; } = new HashSet<BreedingInformation>();

        public virtual ICollection<HealthInformation> DogHealthInformation { get; set; } = new HashSet<HealthInformation>();

        public virtual ICollection<RegistrationDogNumber> RegistrationDogNumbers { get; set; } = new HashSet<RegistrationDogNumber>();

        //public virtual ICollection<ClubRegisterNumber> ClubRegisterNumbers { get; set; } = new HashSet<ClubRegisterNumber>();

    }
}