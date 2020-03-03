namespace Dalmatian.Data.Models
{
    using System;

    using Dalmatian.Data.Common.Models;
    using Dalmatian.Data.Models.Enum;

    public class Dog : BaseDeletableModel<int>
    {
        public string PedigreeName { get; set; }

        public Breed Breed { get; set; }

        public SexDog SexDog { get; set; }

        public Parent Parent { get; set; }

        public int ParentId { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public DateTime? DateOfDeath { get; set; }

        public Color Color { get; set; }

        public Person Person { get; set; }

        public int? PersonId { get; set; }

        public ClubRegisterNumber ClubRegisterNumber { get; set; }

        public int? ClubRegisterNumberId { get; set; }

    }
}