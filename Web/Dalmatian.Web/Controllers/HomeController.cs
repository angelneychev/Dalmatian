using Dalmatian.Services.Data;

namespace Dalmatian.Web.Controllers
{
    using System.Diagnostics;
    using System.Linq;

    using Dalmatian.Data.Common.Repositories;
    using Dalmatian.Data.Models;
    using Dalmatian.Services.Mapping;
    using Dalmatian.Web.ViewModels;
    using Dalmatian.Web.ViewModels.Home;
    using Microsoft.AspNetCore.Mvc;

    public class HomeController : BaseController
    {
        private readonly IDogsService dogsService;

        public HomeController(IDogsService dogsService)
        {
            this.dogsService = dogsService;
        }

        public IActionResult Index()
        {
            var viewModel = new IndexViewModel
            {
                Dogs = this.dogsService.GetAll<IndexDogsViewModel>(),
            };

            return this.View(viewModel);
        }

        public IActionResult Privacy()
        {
            return this.View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return this.View(
                new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
        }
    }
}
