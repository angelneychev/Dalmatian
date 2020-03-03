namespace Dalmatian.Data.Models
{
    using System;

    using Dalmatian.Data.Common.Models;
    using Dalmatian.Data.Models.Enum;

    public class ConfirmationOfMating : BaseDeletableModel<int>
    {
        public string RegistrationNumber { get; set; }

        public Dog DogMale { get; set; }

        public int DogMaleId { get; set; }

        public Dog DogFemale { get; set; }

        public int DogFemaleId { get; set; }

        public DateTime DateOfMating { get; set; }

        public TypeOfMating TypeOfMating { get; set; }
    }
}