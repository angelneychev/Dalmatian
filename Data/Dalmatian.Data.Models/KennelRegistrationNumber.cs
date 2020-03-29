﻿namespace Dalmatian.Data.Models
{
    using System;
    using System.Collections.Generic;

    using Dalmatian.Data.Common.Models;

    public class KennelRegistrationNumber : BaseDeletableModel<int>
    {
        public string RegistrationNumber { get; set; }

        public int DogId { get; set; }

        public Dog Dog { get; set; }

        public DateTime DateOfKennelRegistration { get; set; }
    }
}