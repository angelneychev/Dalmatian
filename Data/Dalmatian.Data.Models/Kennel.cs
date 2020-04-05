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

        public int PersonOwnerId { get; set; }

        public Person PersonOwner { get; set; }

        public int? PersonCoOwnerId { get; set; }

        public Person PersonCoOwner { get; set; }
    }
}
