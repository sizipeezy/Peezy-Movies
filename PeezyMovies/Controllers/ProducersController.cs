namespace PeezyMovies.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using PeezyMovies.Core.Contracts;
    using PeezyMovies.Core.Models;
    using PeezyMovies.Core.Services;

    public class ProducersController : Controller
    {
        private readonly IProducerService producerService;

        public ProducersController(IProducerService producerService)
        {
            this.producerService = producerService;
        }

        public async Task<IActionResult> Index()
        {
            var viewModel = await producerService.GetAllAsync();

            return View(viewModel);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(AddProducerViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.View(model);
            }

            await producerService.AddProducerAsync(model);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int id)
        {
            var viewModel = await producerService.GetByIdAsync(id);
            return this.View(viewModel);
        }

        [HttpGet]
        public IActionResult Edit(int actorId)
        {
            var viewModel = producerService.GetById(actorId);
            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(AddProducerViewModel model, int actorId)
        {
            if (!ModelState.IsValid)
            {
                return this.View(model);
            }

            await producerService.EditProducerDetailAsync(model, actorId);
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
            var producer = producerService.GetById(id);
            if (producer == null)
            {
                return View("NotFound");
            }

            await producerService.DeleteProducerAsync(id);
            return this.RedirectToAction(nameof(Index));
        }

    }
}
