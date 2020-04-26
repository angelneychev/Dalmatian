using System.Linq;

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

        public IActionResult Index()
        {
            var birthCertificate =
                this.birthCertificatesService.GetAll<BirthCertificateViewModel>().ToList();

            var viewModel = new BirthCertificateAllModel()
            {
                BirthCertificates = birthCertificate,
            };

            return this.View(viewModel);
        }

        [Authorize(Roles = "Administrator, ClubMember")]
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
        [Authorize(Roles = "Administrator, ClubMember")]
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

        [Authorize(Roles = "Administrator, ClubMember")]
        public async Task<IActionResult> Edit(int id)
        {
            var person = this.personsService.GetAll<PersonDropDownViewModel>().ToList();

            var kennel = this.kennelsService.GetAll<KennelsDropDownViewModel>().ToList();

            var confirmationOfMating = this.confirmationOfMatingService.GetAll<ConfirmationOfMatingDropDownViewModel>().ToList();


            if (!await this.birthCertificatesService.DoesIdExits(id))
            {
                return this.NotFound();
            }

            var model = this.birthCertificatesService.GetByBirthCertificateId(id);

            model.Persons = person;
            model.Kennels = kennel;
            model.ConfirmationOfMatings = confirmationOfMating;

            return this.View(model);
        }

        [HttpPost]
        [Authorize(Roles = "Administrator, ClubMember")]
        public async Task<IActionResult> Edit(BirthCertificateEditModel input)
        {
            if (!await this.birthCertificatesService.DoesIdExits(input.Id))
            {
                return this.NotFound();
            }

            await this.birthCertificatesService.UpdateBirthCertificate(input);

            return this.RedirectToAction(nameof(this.Details), new { id = input.Id });
        }
    }
}
