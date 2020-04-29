using System.Linq;
using Dalmatian.Web.ViewModels.Dogs;
using Dalmatian.Web.ViewModels.Persons;

namespace Dalmatian.Web.Areas.Administration.Controllers
{
    using Dalmatian.Services.Data;
    using Dalmatian.Web.ViewModels.Administration.Dashboard;

    using Microsoft.AspNetCore.Mvc;

    public class DashboardController : AdministrationController
    {
        private readonly ISettingsService settingsService;
        private readonly IDogsService dogsService;
        private readonly IPersonsService persons;

        public DashboardController(ISettingsService settingsService, IDogsService dogsService, IPersonsService persons)
        {
            this.settingsService = settingsService;
            this.dogsService = dogsService;
            this.persons = persons;
        }

        public IActionResult Index()
        {
            var viewModel = new IndexViewModel
            {
                DogCount = this.dogsService.GetDogCount(),
                DogBaerTestCount = this.dogsService.GetDogBaerTestCount(),
                DogHipRatingCount = this.dogsService.GetDogHipRatingCount(),
                DogLiveCount = this.dogsService.GetDogLiveCount(),
                DogDeadCount = this.dogsService.GetDogDeadCount(),
                DogNewRegisters = this.dogsService.GetDogNewRegister().Cast<DogNewRegisterViewModel>(),
                Persons = this.persons.GetTenPersons(),
                DogMaleCount = this.dogsService.GetDogMaleCount(),
                DogFemaleCount = this.dogsService.GetDogFemaleCount(),
                DogColorBlackCount = this.dogsService.GetDogColorBlackCount(),
                DogColorBrownCount = this.dogsService.GetDogColorBrownCount(),
            };

            return this.View(viewModel);
        }
    }
}
