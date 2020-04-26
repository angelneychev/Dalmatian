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
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IPersonsService personsService;

        public DogsController(IDogsService dogsService, UserManager<ApplicationUser> userManager, IPersonsService personsService)
        {
            this.dogsService = dogsService;
            this.userManager = userManager;
            this.personsService = personsService;
        }

        public IActionResult ByDogName(string pedigreeName)
        {
            var parents = this.dogsService.GetAll<DogDropDownViewModel>();

            var dogName = this.dogsService.GetByName<DogsViewModel>(pedigreeName);

            var litter = this.dogsService.FindByLitterListDog<LitterListDogViewModel>(dogName.Id);

            var siblings =
                this.dogsService.FindBySiblingsDog<SiblingDogViewModel>(dogName.Id);

            dogName.DogLitterList = litter;
            dogName.SiblingDogViewModels = siblings;

            return this.View(dogName);
        }

        [Authorize(Roles = "Administrator, ClubMember")]
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
        [Authorize(Roles = "Administrator, ClubMember")]
        public async Task<IActionResult> CreateDog(DogCreateInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            var user = await this.userManager.GetUserAsync(this.User);
            var dogId = await this.dogsService.CreateAsync(input);
           // var pedigreeName1 = this.dogsService.GetAll<Dog>().Where(x => x.Id == dogId).Select(x => x.PedigreeName).First();
            //var name = this.dogsService.GetByName<Dog>(input.PedigreeName);

            //var pedigreeName = name.PedigreeName;

            return this.Redirect($"/club-dogs/{ input.PedigreeName.Replace(' ', '-') + "-" + dogId}");
        }

        [HttpGet]
        [Authorize(Roles = "Administrator, ClubMember")]
        public async Task<IActionResult> Edit(int id)
        {
            if (!await this.dogsService.DoesIdExits(id))
            {
                return this.NotFound();
            }

            var parents = this.dogsService.GetAll<DogDropDownViewModel>();

            var person = this.personsService.GetAll<PersonDropDownViewModel>();

            var model = this.dogsService.GetByDogId(id);

            model.Persons = person;
            model.Parents = parents;

            return this.View(model);
        }

        [HttpPost]
        [Authorize(Roles = "Administrator, ClubMember")]
        public async Task<IActionResult> Edit(DogEditViewModel input)
        {
            if (!await this.dogsService.DoesIdExits(input.Id))
            {
                return this.NotFound();
            }

            await this.dogsService.UpdateDog(input);

            //var pedigreeName = this.dogsService.GetAll<Dog>().Where(x => x.Id == input.Id).Select(x => x.PedigreeName).FirstOrDefault();

            return this.Redirect($"/club-dogs/{input.PedigreeName.Replace(' ', '-') + "-" + input.Id}");
        }
    }
}
