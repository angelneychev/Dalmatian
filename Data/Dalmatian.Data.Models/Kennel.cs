namespace Dalmatian.Data.Models
{
    using Dalmatian.Data.Common.Models;
    using Dalmatian.Data.Models.Enum;

    public class Kennel : BaseDeletableModel<int>
    {
        public string Name { get; set; }

        public string RegistrationNumber { get; set; }

        public Country Country { get; set; }

        public string City { get; set; }

        public int BreederId { get; set; }

        public Breeder Breeder { get; set; }
    }
}
