namespace Dalmatian.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Dalmatian.Services.Data;
    using Dalmatian.Web.ViewModels.ConfirmationOfMating;
    using Dalmatian.Web.ViewModels.Dogs;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    public class ConfirmationOfMatingController : Controller
    {
        private readonly IDogsService dogsService;
        private readonly IConfirmationOfMatingService confirmationOfMatingService;

        public ConfirmationOfMatingController(IDogsService dogsService, IConfirmationOfMatingService confirmationOfMatingService)
        {
            this.dogsService = dogsService;
            this.confirmationOfMatingService = confirmationOfMatingService;
        }

        public IActionResult Index()
        {
            var dogFather = this.dogsService.GetAll<DogsViewModel>().ToList();

            var confirmationOfMatings =
                this.confirmationOfMatingService.GetAll<ConfirmationOfMatingViewModel>().ToList();

            var viewModel = new ConfirmationOfMatingAllViewModel()
            {
                ConfirmationOfMatings = confirmationOfMatings,
            };

            return this.View(viewModel);
        }

        public IActionResult Details(int id)
        {
            var confirmationOfMatingViewModel = this.confirmationOfMatingService.Details(id);
            if (confirmationOfMatingViewModel == null)
            {
                return this.NotFound();
            }

            return this.View(confirmationOfMatingViewModel);
        }

        [Authorize(Roles = "Administrator, ClubMember")]
        public IActionResult CreateConfirmationOfMating()
        {
            var parents = this.dogsService.GetAll<DogDropDownViewModel>();

            var viewModel = new ConfirmationOfMatingInputModel
            {
                Parents = parents,
            };
            return this.View(viewModel);
        }

        [HttpPost]
        [Authorize(Roles = "Administrator, ClubMember")]
        public async Task<IActionResult> CreateConfirmationOfMating(ConfirmationOfMatingInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            var confirmationOfMatingId = await this.confirmationOfMatingService.CreateAsync(input);

            this.TempData["InfoMessage"] = "Confirmation of mating created!";
            return this.RedirectToAction(nameof(this.Details), new { id = confirmationOfMatingId });
        }

        [Authorize(Roles = "Administrator, ClubMember")]
        public async Task<IActionResult> Edit(int id)
        {
            var parents = this.dogsService.GetAll<DogDropDownViewModel>();

            if (!await this.confirmationOfMatingService.DoesIdExits(id))
            {
                return this.NotFound();
            }

            var model = this.confirmationOfMatingService.GetByConfirmationOfMatingId(id);

            model.Parents = parents;

            return this.View(model);
        }

        [HttpPost]
        [Authorize(Roles = "Administrator, ClubMember")]
        public async Task<IActionResult> Edit(ConfirmationOfMatingEditModel input)
        {
            var parents = this.dogsService.GetAll<DogDropDownViewModel>();

            if (!await this.confirmationOfMatingService.DoesIdExits(input.Id))
            {
                return this.NotFound();
            }

            await this.confirmationOfMatingService.UpdateConfirmationOfMating(input);

            return this.RedirectToAction(nameof(this.Details), new { id = input.Id });
        }
    }
}
