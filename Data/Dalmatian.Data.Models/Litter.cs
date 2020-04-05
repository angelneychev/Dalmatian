namespace Dalmatian.Data.Models
{
    using System;

    using Dalmatian.Data.Common.Models;
    using Dalmatian.Data.Models.Enum;

    public class Litter : BaseDeletableModel<int>
    {
        public string RegistrationNumber { get; set; }

        public DateTime DateOfBirth { get; set; }

        public ConfirmationOfMating ConfirmationOfMating { get; set; }

        public int ConfirmationOfMatingId { get; set; }

        public int NumberOfPuppies { get; set; }

        public int NumberOfMales { get; set; }

        public int NumberOfFemales { get; set; }

        public Person Person { get; set; }

        public int PersonId { get; set; }

        public LetterOfLitter LetterOfLitter { get; set; }
    }
}
