namespace PeezyMovies.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity.UI.Services;
    using Microsoft.AspNetCore.Mvc;
    using PeezyMovies.Core.Contracts;
    using PeezyMovies.Core.Models;
    using SendGrid;
    using SendGrid.Helpers.Mail;

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
        public IActionResult Contact()
        {

            return View();
        }


        public async Task<IActionResult> SendEmail(ContactFormViewModel model)
        {
            var appiKey = WebAppDataConstants.ApiKey;
            var client = new SendGridClient(appiKey);
            var from = new EmailAddress(model.Email, model.Name);
            var subject = model.Subject;
            var to = new EmailAddress("kaynewestsouth@gmail.com", "Example User");
            var plainTextContent = model.Content;
            var htmlContent = "<strong>and easy to do anywhere, even with C#</strong>";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var response = await client.SendEmailAsync(msg);


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
