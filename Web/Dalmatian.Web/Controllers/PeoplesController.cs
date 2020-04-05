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

    public class PeoplesController : Controller
    {
        private readonly IPeoplesService peopleService;
        private readonly UserManager<ApplicationUser> userManager;

        public PeoplesController(IPeoplesService peopleService, UserManager<ApplicationUser> userManager)
        {
            this.peopleService = peopleService;
            this.userManager = userManager;
        }

        [Authorize]
        public IActionResult CreatePeople()
        {
            return this.View();
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreatePeople(PeopleInputModel input)
        {
            var userEmail = await this.userManager.GetUserAsync(this.User);
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            if (input.Email == this.User.Identity.Name)
            {
                input.UserId = this.userManager.GetUserId(this.User);
            }

            var peopleId = await this.peopleService.CreateAsync(input);

           // this.TempData["InfoMessage"] = "Confirmation of People created!";

            return this.RedirectToAction(nameof(this.Details), new { id = peopleId });
        }

        public IActionResult Details(int id)
        {
            var peopleViewModel = this.peopleService.Details(id);
            if (peopleViewModel == null)
            {
                return this.NotFound();
            }

            return this.View(peopleViewModel);
        }
    }
}
