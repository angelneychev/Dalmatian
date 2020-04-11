namespace Dalmatian.Web.Controllers
{
    using System.Threading.Tasks;

    using Dalmatian.Services.Data;
    using Dalmatian.Web.ViewModels.BirthCertificate;
    using Dalmatian.Web.ViewModels.ConfirmationOfMating;
    using Dalmatian.Web.ViewModels.Kennels;
    using Dalmatian.Web.ViewModels.Persons;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    public class BirthCertificatesController : Controller
    {
        private readonly IBirthCertificatesService birthCertificatesService;
        private readonly IPersonsService personsService;
        private readonly IKennelsService kennelsService;
        private readonly IConfirmationOfMatingService confirmationOfMatingService;

        public BirthCertificatesController(
            IBirthCertificatesService birthCertificatesService,
            IPersonsService personsService,
            IKennelsService kennelsService,
            IConfirmationOfMatingService confirmationOfMatingService)
        {
            this.birthCertificatesService = birthCertificatesService;
            this.personsService = personsService;
            this.kennelsService = kennelsService;
            this.confirmationOfMatingService = confirmationOfMatingService;
        }

        // GET
        [Authorize]
        public IActionResult CreateBirthCertificate()
        {
            var person = this.personsService.GetAll<PersonDropDownViewModel>();

            var kennel = this.kennelsService.GetAll<KennelsDropDownViewModel>();

            var confirmationOfMating = this.confirmationOfMatingService.GetAll<ConfirmationOfMatingDropDownViewModel>();

            var viewModel = new BirthCertificateInputModel()
            {
                Persons = person,
                Kennels = kennel,
                ConfirmationOfMatings = confirmationOfMating,
            };
            return this.View(viewModel);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreateBirthCertificate(BirthCertificateInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            var birthCertificateId = await this.birthCertificatesService.CreateAsync(input);

            return this.RedirectToAction(nameof(this.Details), new { id = birthCertificateId });
        }

        public IActionResult Details(int id)
        {
            var viewModel = this.birthCertificatesService.Details(id);
            if (viewModel == null)
            {
                return this.NotFound();
            }

            return this.View(viewModel);
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
