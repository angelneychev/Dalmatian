namespace Dalmatian.Data.Models
{
    using Dalmatian.Data.Common.Models;
    using Dalmatian.Data.Models.Enum;

    public class BreedingInformation : BaseDeletableModel<int>
    {
        public HeightUnits HeightUnits { get; set; }

        public double Height { get; set; }

        public WeightUnits WeightUnits { get; set; }

        public double Weight { get; set; }

        public BreedingStatus BreedingStatus { get; set; }

        public Country CountryOfOrigin { get; set; }

        public Country CountryOfResidence { get; set; }

        public int DogId { get; set; }

        public Dog Dog { get; set; }
    }
}
