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

        public int DogLiveCount { get; set; }

        public int DogDeadCount { get; set; }

        public int DogMaleCount { get; set; }

        public int DogFemaleCount { get; set; }

        public int DogColorBrownCount { get; set; }

        public int DogColorBlackCount { get; set; }

        public IEnumerable<DogNewRegisterViewModel> DogNewRegisters { get; set; }

        public IEnumerable<PersonViewModel> Persons { get; set; }
    }
}
