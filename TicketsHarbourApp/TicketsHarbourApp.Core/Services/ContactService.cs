using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketsHarbourApp.Infastructure.Data;
using TicketsHarbourApp.Infrastructure.Data.Domain;
using TicketsHarbourApp.Core.Contracts;

namespace TicketsHarbourApp.Core.Services
{
    public class ContactService:IContactService
    {
        private readonly ApplicationDbContext _context;

        public ContactService(ApplicationDbContext context)
        {
            _context = context;
        }


     
        public bool Create(string email, string names, string message)
        {
            Contact item = new Contact
            {

                Email = email,
                Names = names,
                Message = message

            };
            _context.Contacts.Add(item);
            return _context.SaveChanges() != 0;
        }


        List<Contact> IContactService.GetMessages()
        {
            return _context.Contacts.ToList();
        }


    }
}
