using System.Linq;

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
        public IActionResult Index(string search = null)
        {
            if (!string.IsNullOrEmpty(search))
            {
                var searchPersons = new PersonsAllViewModel()
                {
                    Persons = this.personService.SearchPersons<PersonViewModel>(search),
                };

                return this.View(searchPersons);
            }

            var persons = this.personService.GetAll<PersonViewModel>().ToList();

            var viewModel = new PersonsAllViewModel()
            {
                Persons = persons,
            };

            return this.View(viewModel);
        }

        [Authorize(Roles = "Administrator, ClubMember")]
        public IActionResult CreatePerson()
        {
            return this.View();
        }

        [HttpPost]
        [Authorize(Roles = "Administrator, ClubMember")]
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

        [Authorize]
        public IActionResult Details(int id)
        {
            var personViewModel = this.personService.Details(id);
            if (personViewModel == null)
            {
                return this.NotFound();
            }

            return this.View(personViewModel);
        }

        [HttpGet]
        [Authorize(Roles = "Administrator, ClubMember")]
        public async Task<IActionResult> Edit(int id)
        {

            if (!await this.personService.DoesIdExits(id))
            {
                return this.NotFound();
            }

            var model = this.personService.GetByPersonId(id);

            return this.View(model);
        }

        [HttpPost]
        [Authorize(Roles = "Administrator, ClubMember")]
        public async Task<IActionResult> Edit(PersonEditModel input)
        {
            if (!await this.personService.DoesIdExits(input.Id))
            {
                return this.NotFound();
            }

            await this.personService.UpdatePerson(input);

            return this.RedirectToAction(nameof(this.Details), new { id = input.Id });
        }
    }
}
