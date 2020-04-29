namespace Dalmatian.Web.Controllers
{
    using System.Diagnostics;

    using Dalmatian.Services.Data;
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

        public IActionResult Index(string search = null)
        {
            if (!string.IsNullOrEmpty(search))
            {
                var searchDogs = new IndexViewModel()
                {
                    Dogs = this.dogsService.SearchDogs<IndexDogsViewModel>(search),
                };

                return this.View(searchDogs);
            }

            var viewModel = new IndexViewModel
            {
                Dogs = this.dogsService.GetAll<IndexDogsViewModel>(),
            };
            return this.View(viewModel);
        }

        [HttpGet("search")]
        public JsonResult AutocompleteResult(string search)
        {
            return this.Json(this.dogsService.SearchDogs<IndexDogsViewModel>(search));
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
