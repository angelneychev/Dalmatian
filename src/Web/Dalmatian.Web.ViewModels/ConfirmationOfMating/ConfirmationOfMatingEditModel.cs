﻿namespace Dalmatian.Web.ViewModels.ConfirmationOfMating
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Dalmatian.Data.Models;
    using Dalmatian.Data.Models.Enum;
    using Dalmatian.Services.Mapping;
    using Dalmatian.Web.ViewModels.Dogs;

    public class ConfirmationOfMatingEditModel : IMapTo<ConfirmationOfMating>, IMapFrom<ConfirmationOfMating>
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "* Registration number confirmation of mating")]
        public string RegistrationNumber { get; set; }

        [Required]
        [Display(Name = "* Father")]
        public int DogFatherId { get; set; }

        [Required]
        [Display(Name = "* Mother")]
        public int DogMotherId { get; set; }

        [Required]
        [Display(Name = "* Date of mating")]
        [DataType(DataType.Date)]
        public DateTime DateOfMating { get; set; }

        [Required]
        [Display(Name = "* Estimated date of birth")]
        [DataType(DataType.Date)]
        public DateTime EstimatedDateOfBirth { get; set; }

        [Required]
        [Display(Name = "* Type of mating")]
        public TypeOfMating TypeOfMating { get; set; }

        [Required]
        [Display(Name = "* Owner male dog")]
        public string OwnerMaleDog { get; set; }

        [Required]
        [Display(Name = "* Owner female dog")]
        public string OwnerFemaleDog { get; set; }

        public IEnumerable<DogDropDownViewModel> Parents { get; set; }
    }
}
