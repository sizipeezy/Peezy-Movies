namespace PeezyMovies.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using PeezyMovies.Core.Contracts;
    using PeezyMovies.Core.Models;

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

        public IActionResult Details(int actorId)
        {
            var viewModel = actorService.GetById(actorId);
            return this.View(viewModel);
        }
        public async Task<IActionResult> Details(AddActorViewModel model, int actorId)
        {
            if (!ModelState.IsValid)
            {
                return this.View(model);
            }

            await actorService.EditActorDetailsAsync(model, actorId);
            return this.RedirectToAction(nameof(Index));
        }

    }
}
