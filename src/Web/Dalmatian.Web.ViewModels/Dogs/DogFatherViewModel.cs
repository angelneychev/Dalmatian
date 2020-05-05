namespace Dalmatian.Web.ViewModels.Dogs
{
    using System.Collections.Generic;

    using Dalmatian.Data.Models;
    using Dalmatian.Services.Mapping;

    public class DogFatherViewModel : IMapFrom<Dog>
    {
        public string PedigreeName { get; set; }

        public int? FatherDogId { get; set; }

        public Dog Father { get; set; }

        public ICollection<Dog> SubFathers { get; set; }
    }
}
