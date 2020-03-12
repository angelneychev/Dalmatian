namespace Dalmatian.Data.Models
{
    using System;
    using System.Collections.Generic;
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
            this.Parents = new HashSet<Parent>();
        }

        public string PedigreeName { get; set; }

        public Breed Breed { get; set; }

        public SexDog SexDog { get; set; }

        public string ImagesUrl { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public DateTime? DateOfDeath { get; set; }

        public Color Color { get; set; }

        public string OwnerName { get; set; }

        public string BreederName { get; set; }

        public virtual ICollection<Parent> Parents { get; set; }

        public ICollection<ClubRegisterNumber> ClubRegisterNumbers { get; set; }

        public virtual ICollection<BreedingInformation> BreedingInformations { get; set; }

        public virtual ICollection<HealthInformation> HealthInformations { get; set; }

        public virtual ICollection<RegistrationDogNumber> RegistrationDogNumbers { get; set; }
    }
}
