namespace PeezyMovies.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using PeezyMovies.Core.Contracts;
    using PeezyMovies.Core.Models;

    public class CinemaController : Controller
    {
        private readonly ICinemaService cinemaService;

        public CinemaController(ICinemaService cinemaService)
        {
            this.cinemaService = cinemaService;
        }

        public async Task<IActionResult> Index()
        {
            var viewModel = await cinemaService.GetAllAsync();
            return View(viewModel);
        }

        [HttpGet]
        public IActionResult Add()
        {
            var viewModel = new AddCinemaViewModel() { };
            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult>  Add(AddCinemaViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.View(model);
            }

            await cinemaService.AddCinemaAsync(model);

            return this.RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var cinema =  cinemaService.GetById(id);
            if(cinema == null)
            {
                return this.View("NotFound");
            }
            return this.View(cinema);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, AddCinemaViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.View(model);
            }

            await cinemaService.UpdateCinemaAsync(model, id);
            return this.RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public  IActionResult Delete()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var cinema = cinemaService.GetById(id);
            if(cinema == null)
            {
                return View("NotFound");
            }

            await cinemaService.DeleteCinemaAsync(id);
            return this.RedirectToAction(nameof(Index));
        }
    }
}
