namespace Dalmatian.Web.Controllers
{
    using System.Threading.Tasks;

    using Dalmatian.Services.Data;
    using Dalmatian.Web.ViewModels.Kennels;
    using Dalmatian.Web.ViewModels.Persons;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    public class KennelsController : Controller
    {
        private readonly IKennelsService kennelService;
        private readonly IPersonsService personsService;

        public KennelsController(IKennelsService kennelService, IPersonsService personsService)
        {
            this.kennelService = kennelService;
            this.personsService = personsService;
        }

        [Authorize]
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
        [Authorize]
        public async Task<IActionResult> CreateKennel(KennelInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            var personId = await this.kennelService.CreateAsync(input);

            return this.RedirectToAction(nameof(this.Details), new { id = personId });
        }

        public IActionResult Details(int id)
        {
            var kennelViewModel = this.kennelService.Details(id);
            if (kennelViewModel == null)
            {
                return this.NotFound();
            }

            return this.View(kennelViewModel);
        }

        public IActionResult Index()
        {
            throw new System.NotImplementedException();
        }

        public IActionResult Edit()
        {
            throw new System.NotImplementedException();
        }
    }
}
