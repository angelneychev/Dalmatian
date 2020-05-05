namespace Dalmatian.Web.ViewModels.Dogs
{
    using System.Collections.Generic;

    using Dalmatian.Data.Models;
    using Dalmatian.Data.Models.Enum;
    using Dalmatian.Services.Mapping;

    public class BreedingInformationViewModel : IMapFrom<BreedingInformation>
    {
        public int Id { get; set; }

        public HeightUnits HeightUnits { get; set; }

        public double Height { get; set; }

        public WeightUnits WeightUnits { get; set; }

        public double Weight { get; set; }

        public BreedingStatus BreedingStatus { get; set; }

        public Country CountryOfOrigin { get; set; }

        public Country CountryOfResidence { get; set; }

        public virtual ICollection<Dog> Dogs { get; set; }
    }
}
