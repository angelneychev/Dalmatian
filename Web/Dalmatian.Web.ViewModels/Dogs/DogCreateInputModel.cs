using System.Collections.Generic;
using System.Linq;

namespace Dalmatian.Web.ViewModels.Dogs
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Web.WebPages.Html;
    using Dalmatian.Data.Models;
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

        [DisplayFormat(DataFormatString = "{0:dd MMM yyyy")]
        public DateTime? DateOfBirth { get; set; }

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

        public DateTime DateOfClubRegister { get; set; }

        //RegistrationDogNumber
        public string RegistrationNumber { get; set; }

        public DateTime DateOfRegistrationNumber { get; set; }

        //HealthInformation
        public Baer Baer { get; set; }

        public DateTime DateOfBaer { get; set; }

        public HipRating HipRating { get; set; }

        public DateTime DateOfElbowRating { get; set; }

        public ElbowRating ElbowRating { get; set; }

        public DateTime DateOfHealthTest { get; set; }

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
