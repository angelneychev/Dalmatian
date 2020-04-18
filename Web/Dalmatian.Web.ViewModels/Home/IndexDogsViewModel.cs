namespace Dalmatian.Web.ViewModels.Home
{
    using System;
    using System.Collections.Generic;

    using Dalmatian.Data.Models;
    using Dalmatian.Data.Models.Enum;
    using Dalmatian.Services.Mapping;

    public class IndexDogsViewModel : IMapFrom<Dog>
    {
        public int Id { get; set; }

        public string PedigreeName { get; set; }

        public SexDog SexDog { get; set; }

        public string OwnerName { get; set; }

        public string BreederName { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public DateTime? DateOfDeath { get; set; }

        public int? PersonOwnerId { get; set; }

        public Person PersonOwner { get; set; }

        public int? PersonBreederId { get; set; }

        public Person PersonBreeder { get; set; }

        public int? FatherDogId { get; set; }

        public string Url => $"/club-dogs/{ this.PedigreeName.Replace(' ', '-') + "-" + this.Id}";
    }
}
