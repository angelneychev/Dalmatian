namespace Dalmatian.Data.Models
{
    using Dalmatian.Data.Common.Models;

    public class Parent : BaseDeletableModel<int>
    {
        public Dog Dog { get; set; }

        public int DogId { get; set; }

        public int? FatherDogId { get; set; }

        public int? MotherDogId { get; set; }

    }
}