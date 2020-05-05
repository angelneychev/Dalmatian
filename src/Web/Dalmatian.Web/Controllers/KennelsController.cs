namespace Dalmatian.Web.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;

    using Dalmatian.Data.Models;
    using Dalmatian.Services.Data;
    using Dalmatian.Web.ViewModels.Kennels;
    using Dalmatian.Web.ViewModels.Persons;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    public class KennelsController : Controller
    {
        private readonly IKennelsService kennelService;
        private readonly IPersonsService personsService;
        private readonly UserManager<ApplicationUser> userManager;

        public KennelsController(IKennelsService kennelService, IPersonsService personsService, UserManager<ApplicationUser> userManager)
        {
            this.kennelService = kennelService;
            this.personsService = personsService;
            this.userManager = userManager;
        }

        public IActionResult Index()
        {
            var kennels = this.kennelService.GetAll<KennelViewModel>().ToList();
            var viewModel = new KennelAllViewModel
            {
                Kennels = kennels,
            };

            return this.View(viewModel);
        }

        [Authorize(Roles = "Administrator, ClubMember")]
        public IActionResult CreateKennel()
        {
            var person = this.personsService.GetAll<PersonDropDownViewModel>();

            var viewModel = new KennelInputModel
            {
                Persons = person,
            };
            return this.View(viewModel);
        }

        [HttpPost]
        [Authorize(Roles = "Administrator, ClubMember")]
        public async Task<IActionResult> CreateKennel(KennelInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            var kennelId = await this.kennelService.CreateAsync(input);

            return this.RedirectToAction(nameof(this.Details), new { id = kennelId });
        }

        [Authorize]
        [Authorize(Roles = "Administrator, ClubMember")]
        public IActionResult Details(int id)
        {
            var kennelViewModel = this.kennelService.Details(id);
            if (kennelViewModel == null)
            {
                return this.NotFound();
            }

            return this.View(kennelViewModel);
        }

        [HttpGet]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Edit(int id)
        {
            var person = this.personsService.GetAll<PersonDropDownViewModel>();

            if (!await this.kennelService.DoesIdExits(id))
            {
                return this.NotFound();
            }

            var model = this.kennelService.GetByKennelId(id);

            model.Persons = person;

            return this.View(model);
        }

        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Edit(KennelEditModel input)
        {
            if (!await this.kennelService.DoesIdExits(input.Id))
            {
                return this.NotFound();
            }

            await this.kennelService.UpdateKennel(input);

            return this.RedirectToAction(nameof(this.Details), new { id = input.Id });
        }
    }
}
