namespace Dalmatian.Web.ViewModels.Dogs
{
    using System;
    using System.Collections.Generic;

    using Dalmatian.Data.Models;
    using Dalmatian.Data.Models.Enum;
    using Dalmatian.Services.Mapping;

    public class HealthInformationViewModel : IMapFrom<HealthInformation>
    {
        public int Id { get; set; }

        public int DogId { get; set; }

        public Baer Baer { get; set; }

        public DateTime? DateOfBaer { get; set; }

        public HipRating HipRating { get; set; }

        public DateTime? DateOfHipRating { get; set; }

        public ElbowRating ElbowRating { get; set; }

        public DateTime? DateOfElbowRating { get; set; }

        public string OtherHealthTest { get; set; }

        public ICollection<Dog> Dogs { get; set; }

    }
}
