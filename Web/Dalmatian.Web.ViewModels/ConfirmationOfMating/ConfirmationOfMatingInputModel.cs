﻿using System.Collections.Generic;
using Dalmatian.Web.ViewModels.Dogs;

namespace Dalmatian.Web.ViewModels.ConfirmationOfMating
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using Dalmatian.Data.Models.Enum;

    public class ConfirmationOfMatingInputModel
    {
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