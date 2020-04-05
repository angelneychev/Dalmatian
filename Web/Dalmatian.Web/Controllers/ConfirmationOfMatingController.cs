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

        public IActionResult Details(int id)
        {
            var confirmationOfMatingViewModel = this.confirmationOfMatingService.Details(id);
            if (confirmationOfMatingViewModel == null)
            {
                return this.NotFound();
            }

            return this.View(confirmationOfMatingViewModel);
        }

        [Authorize]
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
        [Authorize]
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

        public IActionResult Edit()
        {
            throw new NotImplementedException();
        }

        public IActionResult Index()
        {
            throw new NotImplementedException();
        }
    }
}