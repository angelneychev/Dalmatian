namespace Dalmatian.Web.ViewModels.Dogs
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Dalmatian.Data.Models;
    using Dalmatian.Data.Models.Enum;
    using Dalmatian.Web.ViewModels.Persons;
    using Microsoft.AspNetCore.Http;

    public class DogCreateInputModel
    {
        public int Id { get; set; }

        [Required]
        public string PedigreeName { get; set; }

        [Required]
        public Breed Breed { get; set; }

        [Required]
        public SexDog SexDog { get; set; }

        [DataType(DataType.Upload)]
        public IFormFile ImagesUrl { get; set; }

        [Display(Name = "Date of birth")]
        [DataType(DataType.Date)]
        public DateTime? DateOfBirth { get; set; }

        [Display(Name = "Date of death")]
        [DataType(DataType.Date)]
        public DateTime? DateOfDeath { get; set; }

        [Required]
        [Display(Name = "* Color")]
        public Color Color { get; set; }

        public int? PersonOwnerId { get; set; }

        public Person PersonOwner { get; set; }

        public int? PersonBreederId { get; set; }

        public Person PersonBreeder { get; set; }

        [Display(Name = "Sire")]
        public int? FatherDogId { get; set; }

        [Display(Name = "Dame")]
        public int? MotherDogId { get; set; }

        //ClubRegisterNumber
        public string ClubNumber { get; set; }

        [Display(Name = "Date of registration")]
        [DataType(DataType.Date)]
        public DateTime? DateOfClubRegister { get; set; }

        //RegistrationDogNumber
        public string RegistrationNumber { get; set; }

        [Display(Name = "Date of registration")]
        [DataType(DataType.Date)]
        public DateTime? DateOfRegistrationNumber { get; set; }

        //HealthInformation
        public Baer Baer { get; set; }

        [Display(Name = "Date of Baer test")]
        [DataType(DataType.Date)]
        public DateTime? DateOfBaer { get; set; }

        public HipRating HipRating { get; set; }

        [Display(Name = "Date of Hip Rating test")]
        [DataType(DataType.Date)]
        public DateTime? DateOfHipRating { get; set; }

        public ElbowRating ElbowRating { get; set; }

        [Display(Name = "Date of ElbowRating test")]
        [DataType(DataType.Date)]
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

        public IEnumerable<DogDropDownViewModel> Parents { get; set; }

        public IEnumerable<PersonDropDownViewModel> Persons { get; set; }
    }
}
