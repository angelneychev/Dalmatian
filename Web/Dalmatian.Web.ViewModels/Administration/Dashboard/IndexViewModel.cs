namespace Dalmatian.Web.ViewModels.Administration.Dashboard
{
    using System.Collections.Generic;

    using Dalmatian.Web.ViewModels.Dogs;
    using Dalmatian.Web.ViewModels.Persons;

    public class IndexViewModel
    {
        public int DogCount { get; set; }

        public int DogBaerTestCount { get; set; }

        public int DogHipRatingCount { get; set; }

        public int GetDogLiveCount { get; set; }

        public int GetDogDeadCount { get; set; }

        public IEnumerable<DogNewRegisterViewModel> DogNewRegisters { get; set; }

        public IEnumerable<PersonViewModel> Persons { get; set; }
    }
}
