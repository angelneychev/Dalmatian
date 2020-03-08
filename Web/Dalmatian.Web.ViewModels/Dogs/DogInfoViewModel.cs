namespace Dalmatian.Web.ViewModels.Dogs
{
    using System;
    using System.Collections.Generic;

    using Dalmatian.Data.Models;
    using Dalmatian.Data.Models.Enum;
    using Dalmatian.Services.Mapping;

    public class DogInfoViewModel : IMapFrom<Dog>
    {
        public string PedigreeName { get; set; }

        public SexDog SexDog { get; set; }

        public string OwnerName { get; set; }

        public string BreederName { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public DateTime? DateOfDeath { get; set; }

        public string ImagesUrl { get; set; }
    }
}
