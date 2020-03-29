namespace Dalmatian.Data.Models
{
    using System;
    using System.Collections.Generic;

    using Dalmatian.Data.Common.Models;

    public class ClubRegisterNumber : BaseDeletableModel<int>
    {
        public int DogId { get; set; }

        public Dog Dog { get; set; }

        public string ClubNumber { get; set; }

        public DateTime? DateOfClubRegister { get; set; }
    }
}
