namespace Dalmatian.Web.ViewModels.ConfirmationOfMating
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Dalmatian.Data.Models;
    using Dalmatian.Data.Models.Enum;
    using Dalmatian.Services.Mapping;
    using Dalmatian.Web.ViewModels.Dogs;

    public class ConfirmationOfMatingViewModel : IMapFrom<ConfirmationOfMating>
    {
        public int Id { get; set; }

        public string RegistrationNumber { get; set; }

        public int DogFatherId { get; set; }

        public Dog DogFather { get; set; }

        public int DogMotherId { get; set; }

        public Dog DogMother { get; set; }

        [Display(Name = "Date of mating")]
        [DataType(DataType.Date)]
        public DateTime DateOfMating { get; set; }

        [Display(Name = "Estimated date of birth")]
        [DataType(DataType.Date)]
        public DateTime EstimatedDateOfBirth { get; set; }

        public TypeOfMating TypeOfMating { get; set; }

        public string OwnerMaleDog { get; set; }

        public string OwnerFemaleDog { get; set; }

        public string FatherUrl => $"/club-dogs/{this.DogFather.PedigreeName.Replace(' ', '-') + "-" + this.DogFather.Id}";

        public string MotherUrl => $"/club-dogs/{this.DogMother.PedigreeName.Replace(' ', '-') + "-" + this.DogMother.Id}";
    }
}
