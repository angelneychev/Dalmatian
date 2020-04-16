using System.ComponentModel.DataAnnotations;

namespace Dalmatian.Data.Models
{
    using System;
    using System.Collections.Generic;

    using Dalmatian.Data.Common.Models;

    public class RegistrationDogNumber : BaseDeletableModel<int>
    {
        [MaxLength(20)]
        public string RegistrationNumber { get; set; }

        public DateTime? DateOfRegistrationNumber { get; set; }

        public int DogId { get; set; }

        public Dog Dog { get; set; }
    }
}
