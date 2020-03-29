namespace Dalmatian.Web.ViewModels.Dogs
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Dalmatian.Data.Models.Enum;

    public class DogCreateInputModel
    {
        public int Id { get; set; }

        [Required]
        public string PedigreeName { get; set; }

        [Required]
        public Breed Breed { get; set; }

        [Required]
        public SexDog SexDog { get; set; }

        public string ImagesUrl { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd MMM yyyy")]
        public DateTime? DateOfBirth { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd MMM yyyy")]
        public DateTime? DateOfDeath { get; set; }

        [Required]
        public Color Color { get; set; }

        public string OwnerName { get; set; }

        public string BreederName { get; set; }

        [Display(Name = "Father")]

        public int? FatherDogId { get; set; }

        [Display(Name = "Mother")]

        public int? MotherDogId { get; set; }

        //ClubRegisterNumber
        public string ClubNumber { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd MMM yyyy")]
        public DateTime? DateOfClubRegister { get; set; }

        //RegistrationDogNumber
        public string RegistrationNumber { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd MMM yyyy")]
        public DateTime? DateOfRegistrationNumber { get; set; }

        //HealthInformation
        public Baer Baer { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd MMM yyyy")]
        public DateTime? DateOfBaer { get; set; }

        public HipRating HipRating { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd MMM yyyy")]
        public DateTime? DateOfHipRating { get; set; }

        public ElbowRating ElbowRating { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd MMM yyyy")]
        public DateTime? DateOfElbowRating { get; set; }

        public string OtherHealthTest { get; set; }

        //BreedingInformation
        public HeightUnits HeightUnits { get; set; }

        public double Height { get; set; }

        public WeightUnits WeightUnits { get; set; }

        public double Weight { get; set; }

        public BreedingStatus BreedingStatus { get; set; }

        public Country CountryOfOrigin { get; set; }

        public Country CountryOfResidence { get; set; }

        public string Url => $"/club-dogs/{this.PedigreeName.Replace(' ', '-')}";

        public IEnumerable<DogDropDownViewModel> Parents { get; set; }
    }
}
