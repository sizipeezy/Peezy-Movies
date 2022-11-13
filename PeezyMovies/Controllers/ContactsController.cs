namespace PeezyMovies.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using PeezyMovies.Core.Contracts;
    using PeezyMovies.Core.Models;
    using System.Net.Mail;
    using System.Net;

    public class ContactsController : Controller
    {
        private readonly IContactService contactService;
        private const string RedirectedFromContactForm = "RedirectedFromContactForm";
        public ContactsController(IContactService contactService)
        {
            this.contactService = contactService;
        }

        public IActionResult Contact()
        {

            return View();
        }

        public async Task<IActionResult> SendEmail(ContactFormViewModel model)
        {
            var fromAddress = new MailAddress("peezymovies@gmail.com", model.Name);
            var toAddress = new MailAddress("kaynewestsouth@gmail.com", "To Name");
            var subject = model.Subject;
            var body = model.Content;
            const string fromPassword = "testuser1";

            var smtp = new System.Net.Mail.SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword),
                EnableSsl = true,
            };
            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body + " Message was sent by: " + model.Name + " E-mail: " + model.Email,
            })
            {
                smtp.Send(message);
            }


            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            await contactService.SendEmail(model);
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
