using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketsHarbourApp.Infrastructure.Data.Domain;

namespace TicketsHarbourApp.Core.Contracts
{
    public interface IContactService
    {
        bool Create(string email, string names, string message);

        List<Contact> GetMessages();


    }
}
