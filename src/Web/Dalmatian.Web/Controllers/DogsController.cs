namespace Dalmatian.Web.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Dalmatian.Data.Common.Repositories;
    using Dalmatian.Data.Models;
    using Dalmatian.Services.Data;
    using Dalmatian.Web.ViewModels.ClubRegisterNumber;
    using Dalmatian.Web.ViewModels.Dogs;
    using Dalmatian.Web.ViewModels.Kennels;
    using Dalmatian.Web.ViewModels.Persons;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore.Internal;

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

            // TODO Implement User to Dog

            // var user = await this.userManager.GetUserAsync(this.User);

            var dogId = await this.dogsService.CreateAsync(input).ConfigureAwait(false);

#pragma warning disable CA1062 // Validate arguments of public methods
            return this.Redirect($"/club-dogs/{input.PedigreeName.Replace(' ', '-') + "-" + dogId}");
#pragma warning restore CA1062 // Validate arguments of public methods
        }

        [HttpGet]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Edit(int id)
        {
            if (!await this.dogsService.DoesIdExits(id).ConfigureAwait(false))
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
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Edit(DogEditViewModel input)
        {
#pragma warning disable CA1062 // Validate arguments of public methods
            if (!await this.dogsService.DoesIdExits(input.Id).ConfigureAwait(false))
#pragma warning restore CA1062 // Validate arguments of public methods
            {
                return this.NotFound();
            }

            await this.dogsService.UpdateDog(input).ConfigureAwait(false);

            return this.Redirect($"/club-dogs/{input.PedigreeName.Replace(' ', '-') + "-" + input.Id}");
        }

        [Authorize(Roles = "Administrator, ClubMember")]
        public IActionResult GetDogByHealth()
        {
            var viewModel = new DogAllHealtViewModel
            {
                DogHealtViewModels = this.dogsService.GetDogByHealthTest(),
            };
            return this.View(viewModel);
        }

        [Authorize(Roles = "Administrator, ClubMember")]
        public IActionResult GetDogMale()
        {
            var viewModel = new DogAllSexViewModel
            {
                DogSexViewMode = this.dogsService.GetDogMale(),
            };
            return this.View(viewModel);
        }

        [Authorize(Roles = "Administrator, ClubMember")]
        public IActionResult GetDogFemale()
        {
            var viewModel = new DogAllSexViewModel
            {
                DogSexViewMode = this.dogsService.GetDogFemale(),
            };
            return this.View(viewModel);
        }

        [Authorize(Roles = "Administrator, ClubMember")]
        public IActionResult GetByDogColorBlack()
        {
            var viewModel = new DogAllColorViewModel
            {
                DogColorViewModels = this.dogsService.GetDogColorBlack(),
            };
            return this.View(viewModel);
        }

        [Authorize(Roles = "Administrator, ClubMember")]
        public IActionResult GetByDogColorBrown()
        {
            var viewModel = new DogAllColorViewModel
            {
                DogColorViewModels = this.dogsService.GetDogColorBrown(),
            };
            return this.View(viewModel);
        }
    }
}
