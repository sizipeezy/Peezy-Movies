namespace PeezyMovies.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity.UI.Services;
    using Microsoft.AspNetCore.Mvc;
    using PeezyMovies.Core.Contracts;
    using PeezyMovies.Core.Models;

    [Authorize]
    public class ContactsController : Controller
    {
        private readonly IContactService contactService;
        private readonly IEmailSender emailSender;

        private const string RedirectedFromContactForm = "RedirectedFromContactForm";
        public ContactsController(IContactService contactService,
             IEmailSender emailSender)
        {
            this.emailSender = emailSender;
            this.contactService = contactService;
        }

        [AllowAnonymous]
        public IActionResult Contact() => View();

        public async Task<IActionResult> SendEmail(ContactFormViewModel model)
        {
            await contactService.SendEmail(model);

           if (!this.ModelState.IsValid)
           {
               return this.View(model);
           }

           this.TempData[RedirectedFromContactForm] = true;
            return this.RedirectToAction(nameof(ThankYou));
        }

        public IActionResult ThankYou()
        {
            if (this.TempData[RedirectedFromContactForm] == null)
            {
                return this.NotFound();
            }
            return this.View();
        }
    }
}
