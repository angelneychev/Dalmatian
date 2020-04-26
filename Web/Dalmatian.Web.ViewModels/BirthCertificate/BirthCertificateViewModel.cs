namespace Dalmatian.Web.ViewModels.BirthCertificate
{
    using System;
    using System.Collections.Generic;

    using Dalmatian.Data.Models;
    using Dalmatian.Data.Models.Enum;
    using Dalmatian.Services.Mapping;
    using Dalmatian.Web.ViewModels.ConfirmationOfMating;
    using Dalmatian.Web.ViewModels.Kennels;
    using Dalmatian.Web.ViewModels.Persons;

    public class BirthCertificateViewModel : IMapFrom<BirthCertificate>
    {
        public int Id { get; set; }

        public string RegistrationNumber { get; set; }

        public DateTime DateOfBirth { get; set; }

        public int ConfirmationOfMatingId { get; set; }

        public ConfirmationOfMating ConfirmationOfMating { get; set; }

        public int NumberOfPuppies { get; set; }

        public int NumberOfMales { get; set; }

        public int NumberOfFemales { get; set; }

        public int PersonId { get; set; }

        public Person Person { get; set; }

        public int KennelId { get; set; }

        public Kennel Kennel { get; set; }

        public LetterOfLitter LetterOfLitter { get; set; }

        public IEnumerable<PersonDropDownViewModel> Persons { get; set; }

        public IEnumerable<KennelsDropDownViewModel> Kennels { get; set; }

        public IEnumerable<ConfirmationOfMatingDropDownViewModel> ConfirmationOfMatings { get; set; }
    }
}
