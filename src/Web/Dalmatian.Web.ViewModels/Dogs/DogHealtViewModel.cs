namespace Dalmatian.Web.ViewModels.Dogs
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

    using Dalmatian.Data.Models;
    using Dalmatian.Data.Models.Enum;
    using Dalmatian.Services.Mapping;

    public class DogHealtViewModel : IMapFrom<Dog>, IMapTo<Dog>
    {
        public int Id { get; set; }

        public string PedigreeName { get; set; }

        public Breed Breed { get; set; }

        public SexDog SexDog { get; set; }

        public string ImagesUrl { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd MMM yyyy")]
        public DateTime? DateOfBirth { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd MMM yyyy")]
        public DateTime? DateOfDeath { get; set; }

        public Color Color { get; set; }

        public int? PersonOwnerId { get; set; }

        public Person PersonOwner { get; set; }

        public int? PersonBreederId { get; set; }

        public Person PersonBreeder { get; set; }

        public int? FatherDogId { get; set; }

        public Dog Father { get; set; }

        public int? MotherDogId { get; set; }

        public Dog Mother { get; set; }

        public Baer Baer =>
            this.HealthInformations.Where(x => x.DogId == this.Id).Select(x => x.Baer).FirstOrDefault();

        public DateTime? DateOfBaer =>
            this.HealthInformations.Where(x => x.DogId == this.Id).Select(x => x.DateOfBaer).FirstOrDefault();

        public HipRating HipRating => this.HealthInformations.Where(x => x.DogId == this.Id).Select(x => x.HipRating).FirstOrDefault();

        public DateTime? DateOfHipRating =>
            this.HealthInformations.Where(x => x.DogId == this.Id).Select(x => x.DateOfHipRating).FirstOrDefault();

        public string FatherUrl => $"/club-dogs/{this.Father.PedigreeName.Replace(' ', '-') + "-" + this.Father.Id}";

        public string MotherUrl => $"/club-dogs/{this.Mother.PedigreeName.Replace(' ', '-') + "-" + this.Mother.Id}";

        public string RedirectUrl => $"/club-dogs/{this.PedigreeName.Replace(' ', '-') + "-" + this.Id}";

        public IEnumerable<BreedingInformation> BreedingInformations { get; set; }

        public IEnumerable<ClubRegisterNumber> ClubRegisterNumbers { get; set; }

        public IEnumerable<HealthInformation> HealthInformations { get; set; } = new HashSet<HealthInformation>();

        public IEnumerable<RegistrationDogNumberViewModel> RegistrationDogNumbers { get; set; }

        public IEnumerable<LitterListDogViewModel> DogLitterList = new HashSet<LitterListDogViewModel>();

        public IEnumerable<SiblingDogViewModel> SiblingDogViewModels = new HashSet<SiblingDogViewModel>();
    }
}