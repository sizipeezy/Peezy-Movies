namespace PeezyMovies.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using PeezyMovies.Core.Contracts;
    using PeezyMovies.Core.Models;

    [Authorize(Roles = WebAppDataConstants.Admin)]
    public class ProducersController : Controller
    {
        private readonly IProducerService producerService;

        public ProducersController(IProducerService producerService)
        {
            this.producerService = producerService;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var viewModel = await producerService.GetAllAsync();

            return View(viewModel);
        }

        [HttpGet]
        public IActionResult Create() => View();
       

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

        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            if ((await producerService.Exists(id)) == false)
            {
                return this.NotFound();
            }

            var viewModel = await producerService.GetProducerDetails(id);
            return this.View(viewModel);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var viewModel = producerService.EditById(id);

            return this.View(viewModel);
        }
         

        [HttpPost]
        public async Task<IActionResult> Edit(AddProducerViewModel model, int id)
        {
            if ((await producerService.Exists(id)) == false)
            {
                return this.NotFound();
            }

            if (!ModelState.IsValid)
            {
                return this.View(model);
            }

            await producerService.EditProducerDetailAsync(model, id);
            return this.RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Delete() => View();


        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            if ((await producerService.Exists(id)) == false)
            {
                return this.NotFound();
            }

            await producerService.DeleteProducerAsync(id);

            return this.RedirectToAction(nameof(Index));
        }

    }
}
