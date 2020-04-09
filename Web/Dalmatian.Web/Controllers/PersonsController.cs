namespace Dalmatian.Web.Controllers
{
    using System;
    using System.Threading.Tasks;

    using Dalmatian.Data.Models;
    using Dalmatian.Services.Data;
    using Dalmatian.Web.ViewModels.Persons;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    public class PersonsController : Controller
    {
        private readonly IPersonsService personService;
        private readonly UserManager<ApplicationUser> userManager;

        public PersonsController(IPersonsService personService, UserManager<ApplicationUser> userManager)
        {
            this.personService = personService;
            this.userManager = userManager;
        }

        [Authorize]
        public IActionResult CreatePerson()
        {
            return this.View();
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreatePerson(PersonInputModel input)
        {
            var userEmail = await this.userManager.GetUserAsync(this.User);
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            if (input.Email != null && input.Email == this.User.Identity.Name)
            {
                input.UserId = this.userManager.GetUserId(this.User);
            }

            var personId = await this.personService.CreateAsync(input);

           // this.TempData["InfoMessage"] = "Confirmation of People created!";

            return this.RedirectToAction(nameof(this.Details), new { id = personId });
        }

        public IActionResult Details(int id)
        {
            var personViewModel = this.personService.Details(id);
            if (personViewModel == null)
            {
                return this.NotFound();
            }

            return this.View(personViewModel);
        }

        public IActionResult Index()
        {
            throw new NotImplementedException();
        }

        public IActionResult Edit()
        {
            throw new NotImplementedException();
        }
    }
}
