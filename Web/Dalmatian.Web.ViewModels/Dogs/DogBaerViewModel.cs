namespace Dalmatian.Web.ViewModels.Dogs
{
    using System;

    using Dalmatian.Data.Models;
    using Dalmatian.Data.Models.Enum;
    using Dalmatian.Services.Mapping;

    public class DogBaerViewModel : IMapFrom<HealthInformation>
    {
        public int Id { get; set; }
        public Baer Baer { get; set; }

        public DateTime? DateOfBaer { get; set; }

        public HipRating HipRating { get; set; }
    }
}