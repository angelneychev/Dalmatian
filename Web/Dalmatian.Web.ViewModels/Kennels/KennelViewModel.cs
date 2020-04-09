namespace Dalmatian.Web.ViewModels.Kennels
{
    using System;

    using Dalmatian.Data.Models;
    using Dalmatian.Data.Models.Enum;
    using Dalmatian.Services.Mapping;

    public class KennelViewModel : IMapFrom<Kennel>
    {
        public string Name { get; set; }

        public string RegistrationNumber { get; set; }

        public DateTime DateOfRegistration { get; set; }

        public Country Country { get; set; }

        public string City { get; set; }

        public string Address { get; set; }

        public int PersonOwnerId { get; set; }

        public int? PersonCoOwnerId { get; set; }
    }
}
