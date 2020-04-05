namespace Dalmatian.Data.Models
{
    using System;

    using Dalmatian.Data.Common.Models;
    using Dalmatian.Data.Models.Enum;

    public class Kennel : BaseDeletableModel<int>
    {
        public string Name { get; set; }

        public string RegistrationNumber { get; set; }

        public DateTime DateOfRegistration { get; set; }

        public Country Country { get; set; }

        public string City { get; set; }

        public int PeopleOwnerId { get; set; }

        public People PeopleOwner { get; set; }

        public int? PeopleCoOwnerId { get; set; }

        public People PeopleCoOwner { get; set; }
    }
}
