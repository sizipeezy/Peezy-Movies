namespace PeezyMovies.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using PeezyMovies.Core.Contracts;
    using PeezyMovies.Core.Models;
    using PeezyMovies.Core.Services;

    public class ActorsController : Controller
    {
        private readonly IActorService actorService;

        public ActorsController
            (IActorService actorService)
        {
            this.actorService = actorService;
        
        }

        public async Task<IActionResult> Index()
        {
            var viewModel =await actorService.GetAllAsync();

            return View(viewModel); 
        }

        [HttpGet]
        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(AddActorViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.View(model);
            }

            await actorService.AddActorAsync(model);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Details(int actorId)
        {
            var viewModel = actorService.GetById(actorId);
            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Details(AddActorViewModel model, int actorId)
        {
            if (!ModelState.IsValid)
            {
                return this.View(model);
            }

            await actorService.EditActorDetailsAsync(model, actorId);
            return this.RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Delete()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var actor = actorService.GetById(id);
            if (actor == null)
            {
                return View("NotFound");
            }

            await actorService.DeleteActorAsync(id);
            return this.RedirectToAction(nameof(Index));
        }

    }
}
