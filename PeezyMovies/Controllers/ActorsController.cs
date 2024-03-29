﻿namespace PeezyMovies.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using PeezyMovies.Core.Contracts;
    using PeezyMovies.Core.Models;

    [Authorize(Roles = WebAppDataConstants.Admin)]
    public class ActorsController : Controller
    {
        private readonly IActorService actorService;

        public ActorsController
            (IActorService actorService)
        {
            this.actorService = actorService;

        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var viewModel = await actorService.GetAllAsync();

            return View(viewModel);
        }

        [HttpGet]
        public IActionResult Create() => View();

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

      
        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            if (await actorService.Exists(id) == false)
            {
                return this.NotFound();
            }

            var viewModel = await actorService.GetByIdAsync(id);

            return this.View(viewModel);
        }


        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            if (await actorService.Exists(id) == false)
            {
                return this.NotFound();
            }

            await actorService.DeleteActorAsync(id);

            return this.RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var viewModel = await actorService.ActorById(id);

            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(AddActorViewModel model, int id)
        {
            if (await actorService.Exists(id) == false)
            {
                return this.NotFound();
            }

            if (!ModelState.IsValid)
            {
                return this.View(model);
            }

            await actorService.EditActorDetailsAsync(model, id);

            return this.RedirectToAction(nameof(Index));
        }
    }
}
