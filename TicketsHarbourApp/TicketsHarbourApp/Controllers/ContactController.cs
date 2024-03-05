using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using TicketsHarbourApp.Core.Contracts;
using TicketsHarbourApp.Core.Services;
using TicketsHarbourApp.Infrastructure.Data.Domain;
using TicketsHarbourApp.Models.Contact;
using TicketsHarbourApp.Models.Event;
using TicketsHarbourApp.Models.Statistic;

namespace TicketsHarbourApp.Controllers
{
    public class ContactController : Controller
    {

        private readonly IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            this._contactService = contactService;
        }

        // GET: ContactController
        public ActionResult Index()
        {
            List<ContactIndexVM> messages = _contactService.GetMessages()
               .Select(item => new ContactIndexVM
               {
                   Id = item.Id,
                   Email = item.Email,
                   Names = item.Names,
                   Message = item.Message,
               }).ToList();
            return View(messages);
        }

       
        // GET: ContactController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ContactController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ContactCreateVM contact)
        {
            if (ModelState.IsValid)
            {
                _contactService.Create(contact.Email, contact.Names, contact.Message);
                return RedirectToAction(nameof(Thanks));
            }
            return View(contact);
        }

        // GET: ContactController/Thanks
        public ActionResult Thanks()
        {
            return View();
        }


    }
}
