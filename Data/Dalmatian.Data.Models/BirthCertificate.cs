namespace Dalmatian.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using Dalmatian.Data.Common.Models;
    using Dalmatian.Data.Models.Enum;

    public class BirthCertificate : BaseDeletableModel<int>
    {
        [MaxLength(20)]
        public string RegistrationNumber { get; set; }

        public DateTime DateOfBirth { get; set; }

        public ConfirmationOfMating ConfirmationOfMating { get; set; }

        public int ConfirmationOfMatingId { get; set; }

        public int NumberOfPuppies { get; set; }

        public int NumberOfMales { get; set; }

        public int NumberOfFemales { get; set; }

        public Person Person { get; set; }

        public int PersonId { get; set; }

        public Kennel Kennel { get; set; }

        public int KennelId { get; set; }

        public LetterOfLitter LetterOfLitter { get; set; }
    }
}
