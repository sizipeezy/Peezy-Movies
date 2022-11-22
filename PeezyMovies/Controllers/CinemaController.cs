namespace PeezyMovies.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using PeezyMovies.Core.Contracts;
    using PeezyMovies.Core.Models;

    [Authorize(Roles = "Admin")]
    public class CinemaController : Controller
    {
        private readonly ICinemaService cinemaService;

        public CinemaController(ICinemaService cinemaService)
        {
            this.cinemaService = cinemaService;
        }


        [AllowAnonymous]
        public  async Task<IActionResult> Details(int id)
        {
            if ((await cinemaService.Exists(id)) == false)
            {
                return this.NotFound();
            }

            var cinema = await cinemaService.GetByIdAsync(id);
            return this.View(cinema);
        }


        [AllowAnonymous]
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
            if ((await cinemaService.Exists(id)) == false)
            {
                return this.NotFound();
            }

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
            if ((await cinemaService.Exists(id)) == false)
            {
                return this.NotFound();
            }

            await cinemaService.DeleteCinemaAsync(id);
            return this.RedirectToAction(nameof(Index));
        }
       
    }
}
