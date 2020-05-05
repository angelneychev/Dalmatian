namespace Dalmatian.Web.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Dalmatian.Data.Models;
    using Dalmatian.Services.Data;
    using Dalmatian.Web.ViewModels.Dogs;
    using Dalmatian.Web.ViewModels.Persons;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore.Internal;

    public class PersonsController : Controller
    {
        private readonly IPersonsService personService;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IDogsService dogsService;


        public PersonsController(IPersonsService personService, UserManager<ApplicationUser> userManager, IDogsService dogsService)
        {
            this.personService = personService;
            this.userManager = userManager;
            this.dogsService = dogsService;
        }

        [Authorize(Roles = "Administrator, ClubMember")]
        public IActionResult Index(string search = null, int page = 1)
        {
            var allPersons = this.personService.AllPersons(page);

            var totalPage = this.personService.Total();

            if (!string.IsNullOrEmpty(search))
            {
                var persons = this.personService.SearchPersons<PersonViewModel>(search);

                var searchPersons = new PersonsAllViewModel()
                {
                    Persons = persons,
                    Total = totalPage,
                    CurrentPage = page,
                };

                return this.View(searchPersons);
            }

            var viewModel = new PersonsAllViewModel()
            {
                Persons = allPersons,
                Total = totalPage,
                CurrentPage = page,
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

            return this.RedirectToAction(nameof(this.Details), new { id = personId });
        }

        [Authorize(Roles = "Administrator, ClubMember")]
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
        [Authorize(Roles = "Administrator")]
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
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Edit(PersonEditModel input)
        {
            if (!await this.personService.DoesIdExits(input.Id))
            {
                return this.NotFound();
            }

            await this.personService.UpdatePerson(input);

            return this.RedirectToAction(nameof(this.Details), new { id = input.Id });
        }

        public IActionResult PersonToDog(int id)
        {
            var dogs = this.dogsService.GetAll<DogsViewModel>().Where(x => x.PersonOwnerId == id).ToList();

            var person = this.personService.GetByPersonToDogId(id);

            person.DogsViewModels = dogs;

            return this.View(person);
        }

        public IActionResult BreederToDog(int id)
        {
            var dogs = this.dogsService.GetAll<DogsViewModel>().Where(x => x.PersonBreederId == id).ToList();

            var breeder = this.personService.GetByBreederToDogId(id);

            breeder.DogsViewModels = dogs;

            return this.View(breeder);
        }
    }
}
