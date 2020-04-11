namespace Dalmatian.Web.ViewModels.BirthCertificate
{
    using System;

    using Dalmatian.Data.Models;
    using Dalmatian.Data.Models.Enum;
    using Dalmatian.Services.Mapping;

    public class BirthCertificateViewModel : IMapFrom<BirthCertificate>
    {
        public string RegistrationNumber { get; set; }

        public DateTime DateOfBirth { get; set; }

        public int ConfirmationOfMatingId { get; set; }

        public int NumberOfPuppies { get; set; }

        public int NumberOfMales { get; set; }

        public int NumberOfFemales { get; set; }

        public int PersonId { get; set; }

        public int KennelId { get; set; }

        public LetterOfLitter LetterOfLitter { get; set; }
    }
}