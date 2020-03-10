using System.Linq;

namespace Dalmatian.Web.Controllers
{
    using Dalmatian.Services.Data;
    using Dalmatian.Web.ViewModels.Dogs;
    using Microsoft.AspNetCore.Mvc;

    public class DogsController : Controller
    {
        private readonly IDogsService dogsService;

        public DogsController(IDogsService dogsService)
        {
            this.dogsService = dogsService;
        }

        public IActionResult ByDogName(string pedigreeName)
        {
            var viewMode = this.dogsService.GetByName<DogsViewModel>(pedigreeName);

            return this.View(viewMode);
        }
    }
}
