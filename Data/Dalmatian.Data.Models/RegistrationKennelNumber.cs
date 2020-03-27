namespace Dalmatian.Data.Models
{
    using System;
    using System.Collections.Generic;

    using Dalmatian.Data.Common.Models;

    public class RegistrationKennelNumber : BaseDeletableModel<int>
    {
        public string RegistrationNumber { get; set; }

        public int DogId { get; set; }

        public Dog Dog { get; set; }

        public DateTime DateOfRegister { get; set; }
    }
}
