using System.Collections.Generic;

namespace Dalmatian.Web.Controllers
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using Dalmatian.Data.Common.Repositories;
    using Dalmatian.Data.Models;
    using Dalmatian.Services.Data;
    using Dalmatian.Web.ViewModels.ClubRegisterNumber;
    using Dalmatian.Web.ViewModels.Dogs;
    using Dalmatian.Web.ViewModels.Persons;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    public class DogsController : Controller
    {
        private readonly IDogsService dogsService;
        private readonly IDeletableEntityRepository<Dog> dogsRepository;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IPersonsService personsService;

        public DogsController(IDogsService dogsService, IDeletableEntityRepository<Dog> dogsRepository, UserManager<ApplicationUser> userManager, IPersonsService personsService)
        {
            this.dogsService = dogsService;
            this.dogsRepository = dogsRepository;
            this.userManager = userManager;
            this.personsService = personsService;
        }

        public IActionResult ByDogName(string pedigreeName)
        {

            var parents = this.dogsService.GetAll<DogDropDownViewModel>();
            var dogName = this.dogsService.GetByName<DogsViewModel>(pedigreeName);
            var litter = this.dogsService.FindByLitterListDog<LitterListDogViewModel>(dogName.Id);

            dogName.DogLitterList = litter;
            return this.View(dogName);
        }

        [Authorize]
        public IActionResult CreateDog()
        {
            var parents = this.dogsService.GetAll<DogDropDownViewModel>();

            var person = this.personsService.GetAll<PersonDropDownViewModel>();
            var viewModel = new DogCreateInputModel
            {
                Parents = parents,
                Persons = person,
            };
            return this.View(viewModel);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreateDog(DogCreateInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            var user = await this.userManager.GetUserAsync(this.User);
            var dogId = await this.dogsService.CreateAsync(input);
            var pedigreeName = this.dogsRepository.All().Where(x => x.Id == dogId).Select(x => x.PedigreeName).FirstOrDefault();

            return this.Redirect($"/club-dogs/{pedigreeName.Replace(' ', '-') + "-" + dogId}");
        }

    }
}
