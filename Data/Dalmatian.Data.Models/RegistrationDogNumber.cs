namespace Dalmatian.Data.Models
{
    using System.Collections.Generic;

    using Dalmatian.Data.Common.Models;

    public class RegistrationDogNumber : BaseDeletableModel<int>
    {
        public string RegistrationNumber { get; set; }

        public int DogId { get; set; }

        public Dog Dog { get; set; }
    }
}
