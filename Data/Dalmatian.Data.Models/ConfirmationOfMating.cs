namespace Dalmatian.Data.Models
{
    using System;

    using Dalmatian.Data.Common.Models;
    using Dalmatian.Data.Models.Enum;

    public class ConfirmationOfMating : BaseDeletableModel<int>
    {
        public string RegistrationNumber { get; set; }

        public Dog DogFather { get; set; }

        public int DogFatherId { get; set; }

        public Dog DogMother { get; set; }

        public int DogMotherId { get; set; }

        public DateTime DateOfMating { get; set; }

        public DateTime EstimatedDateOfBirth { get; set; }

        public TypeOfMating TypeOfMating { get; set; }

        public string OwnerMaleDog { get; set; }

        public string OwnerFemaleDog { get; set; }
    }
}
