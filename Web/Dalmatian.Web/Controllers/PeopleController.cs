namespace Dalmatian.Web.Controllers
{
    using System;
    using System.Threading.Tasks;

    using Dalmatian.Data.Models;
    using Dalmatian.Services.Data;
    using Dalmatian.Web.ViewModels.Peoples;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    public class PeopleController : Controller
    {
        private readonly IPeopleService peopleService;
        private readonly IDogsService dogsService;
        private readonly UserManager<ApplicationUser> userManager;

        public PeopleController(IPeopleService peopleService, IDogsService dogsService, UserManager<ApplicationUser> userManager)
        {
            this.peopleService = peopleService;
            this.dogsService = dogsService;
            this.userManager = userManager;
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreatePeople(PeopleInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            var user = await this.userManager.GetUserAsync(this.User);
            var peopleId = await this.peopleService.CreateAsync(input);

            this.TempData["InfoMessage"] = "Confirmation of People created!";
            //return this.RedirectToAction(nameof(this.Details), new { id = peopleId });
            return this.RedirectToAction(nameof(this.Details), new {id = peopleId});
        }

        public IActionResult Edit()
        {
            throw new NotImplementedException();
        }

        public IActionResult Index()
        {
            throw new NotImplementedException();
        }

        public IActionResult Details()
        {
            throw new NotImplementedException();
        }
    }
}