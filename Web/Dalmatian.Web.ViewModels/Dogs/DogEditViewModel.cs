using System.Linq;
using AutoMapper;

namespace Dalmatian.Web.ViewModels.Dogs
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Dalmatian.Data.Models;
    using Dalmatian.Data.Models.Enum;
    using Dalmatian.Services.Mapping;
    using Dalmatian.Web.ViewModels.Persons;
    using Microsoft.AspNetCore.Http;

    public class DogEditViewModel : IMapFrom<Dog>, IMapTo<Dog>
    {
        public int Id { get; set; }

        [Required]
        [RegularExpression(
            @"[^\d^\`|^\~|^\!|^\@|^\#|^\%|^\^^|^\^$|\^*|^\(^|\)|^\+|^\=|^\[|^\{|^\]|^\}|^\||^\\|^\<|^\,|^\.|^\>|^\?|^\/|^\""|^\;|\:]+",
            ErrorMessage = "Characters or number are not allowed.")]
        [MinLength(2)]
        [MaxLength(250)]
        [Display(Name = "* Dog name for Pedigree")]
        public string PedigreeName { get; set; }

        [Required]
        [Display(Name = "* Breed")]
        public Breed Breed { get; set; }

        [Required]
        [Display(Name = "* Sex")]
        public SexDog SexDog { get; set; }

        [DataType(DataType.Upload)]
        [Display(Name = "Add photo dog")]
        public string ImagesUrl { get; set; }

        [Display(Name = "Date of birth")]
        [DataType(DataType.Date)]
        public DateTime? DateOfBirth { get; set; }

        [Display(Name = "Date of death")]
        [DataType(DataType.Date)]
        public DateTime? DateOfDeath { get; set; }

        [Required]
        [Display(Name = "* Color")]
        public Color Color { get; set; }

        [Display(Name = "Owner")]
        public int? PersonOwnerId { get; set; }

        public Person PersonOwner { get; set; }

        [Display(Name = "Breeder")]
        public int? PersonBreederId { get; set; }

        public Person PersonBreeder { get; set; }

        [Display(Name = "Sire")]
        public int? FatherDogId { get; set; }

        [Display(Name = "Dame")]
        public int? MotherDogId { get; set; }

        //ClubRegisterNumber
        [Display(Name = "Club register number")]
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
        [Display(Name = "Baer test")]
        public Baer Baer { get; set; }

        [Display(Name = "Date of test")]
        [DataType(DataType.Date)]
        public DateTime? DateOfBaer { get; set; }

        [Display(Name = "Hip Rating test")]
        public HipRating HipRating { get; set; }

        [Display(Name = "Date of test")]
        [DataType(DataType.Date)]
        public DateTime? DateOfHipRating { get; set; }

        [Display(Name = "Elbow Rating test")]
        public ElbowRating ElbowRating { get; set; }

        [Display(Name = "Date of test")]
        [DataType(DataType.Date)]
        public DateTime? DateOfElbowRating { get; set; }

        [Display(Name = "Other healthg test")]
        public string OtherHealthTest { get; set; }

        //BreedingInformation
        [Display(Name = "Units")]
        public HeightUnits HeightUnits { get; set; }

        [Display(Name = "Height")]
        public double Height { get; set; }

        [Display(Name = "Units")]
        public WeightUnits WeightUnits { get; set; }

        [Display(Name = "Weight")]
        public double Weight { get; set; }

        [Display(Name = "Breeding status")]
        public BreedingStatus BreedingStatus { get; set; }

        [Display(Name = "Country of origins")]
        public Country CountryOfOrigin { get; set; }

        [Display(Name = "Country of residence")]
        public Country CountryOfResidence { get; set; }

        public IEnumerable<DogDropDownViewModel> Parents { get; set; }

        public IEnumerable<PersonDropDownViewModel> Persons { get; set; }

        //public ClubRegisterNumber ClubRegisterNumber { get; set; }

        //  public string RedirectUrl => $"/club-dogs/{this.PedigreeName.Replace(' ', '-') + "-" + this.Id}";

        //public void CreateMappings(IProfileExpression configuration)
        //{
        //    configuration.CreateMap<Dog, DogEditViewModel>()
        //        .ForMember(x => x.ClubNumber), 
        //    options =>
        //        {
        //            options.MapFrom(p => p.);
        //        });
        //}
    }
}
