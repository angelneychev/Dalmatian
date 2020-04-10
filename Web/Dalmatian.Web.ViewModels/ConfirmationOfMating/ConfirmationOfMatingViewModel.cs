namespace Dalmatian.Web.ViewModels.ConfirmationOfMating
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Dalmatian.Data.Models;
    using Dalmatian.Data.Models.Enum;
    using Dalmatian.Services.Mapping;
    using Dalmatian.Web.ViewModels.Dogs;

    public class ConfirmationOfMatingViewModel : IMapFrom<ConfirmationOfMating>, IMapFrom<Dog>
    {
        public int Id { get; set; }

        public string RegistrationNumber { get; set; }

        [Display(Name = "Father")]
        public int FatherDogId { get; set; }

        [Display(Name = "Mother")]
        public int MotherDogId { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateOfMating { get; set; }

        [Display(Name = "* Estimated date of birth")]
        [DataType(DataType.Date)]
        public DateTime EstimatedDateOfBirth { get; set; }

        public TypeOfMating TypeOfMating { get; set; }

        public string OwnerMaleDog { get; set; }

        public string OwnerFemaleDog { get; set; }

        public IEnumerable<DogsViewModel> DogsViewModels { get; set; }
    }
}
