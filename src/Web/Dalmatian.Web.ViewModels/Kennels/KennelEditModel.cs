namespace Dalmatian.Web.ViewModels.Kennels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Dalmatian.Data.Models;
    using Dalmatian.Data.Models.Enum;
    using Dalmatian.Services.Mapping;
    using Dalmatian.Web.ViewModels.Persons;

    public class KennelEditModel : IMapFrom<Kennel>, IMapTo<Kennel>
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "* Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "* RegistrationNumber")]
        public string RegistrationNumber { get; set; }

        [Required]
        [Display(Name = "* Date of registration")]
        [DataType(DataType.Date)]
        public DateTime DateOfRegistration { get; set; }

        [Required]
        [Display(Name = "* Country")]
        public Country Country { get; set; }

        [Required]
        [Display(Name = "* City")]
        public string City { get; set; }

        public string Address { get; set; }

        [Required]
        [Display(Name = "* Owner")]
        public int PersonOwnerId { get; set; }

        [Display(Name = "Co Owner")]
        public int? PersonCoOwnerId { get; set; }

        public IEnumerable<PersonDropDownViewModel> Persons { get; set; }
    }
}