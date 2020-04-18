namespace Dalmatian.Data.Models
{
    using System;

    using Dalmatian.Data.Common.Models;
    using Dalmatian.Data.Models.Enum;

    public class HealthInformation : BaseDeletableModel<int>
    {
        public Baer Baer { get; set; }

        public DateTime? DateOfBaer { get; set; }

        public HipRating HipRating { get; set; }

        public DateTime? DateOfHipRating { get; set; }

        public ElbowRating ElbowRating { get; set; }

        public DateTime? DateOfElbowRating { get; set; }

        public string OtherHealthTest { get; set; }

        public int DogId { get; set; }

        public Dog Dog { get; set; }
    }
}
