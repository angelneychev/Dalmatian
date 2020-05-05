namespace Dalmatian.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using Dalmatian.Data.Common.Models;
    using Dalmatian.Data.Models.Enum;

    public class Kennel : BaseDeletableModel<int>
    {
        [MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(20)]
        public string RegistrationNumber { get; set; }

        public DateTime DateOfRegistration { get; set; }

        public Country Country { get; set; }

        [MaxLength(50)]
        public string City { get; set; }

        [MaxLength(200)]
        public string Address { get; set; }

        public int PersonOwnerId { get; set; }

        public Person PersonOwner { get; set; }

        public int? PersonCoOwnerId { get; set; }

        public Person PersonCoOwner { get; set; }
    }
}
