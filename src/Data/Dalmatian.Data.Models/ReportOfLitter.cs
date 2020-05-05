namespace Dalmatian.Data.Models
{
    using System;

    using Dalmatian.Data.Common.Models;

    public class ReportOfLitter : BaseDeletableModel<int>
    {
        public Litter Litter { get; set; }

        public int LitterId { get; set; }

        public Dog Dog { get; set; }

        public int DogId { get; set; }

        public string BreederInCharge { get; set; }

        public DateTime DateOfExamination { get; set; }
    }
}
