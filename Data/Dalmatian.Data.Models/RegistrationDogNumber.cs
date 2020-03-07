namespace Dalmatian.Data.Models
{
    using Dalmatian.Data.Common.Models;

    public class RegistrationDogNumber : BaseDeletableModel<int>
    {
        public string RegistrationNumber { get; set; }

        public Dog Dog { get; set; }

        public int DogId { get; set; }
    }
}
