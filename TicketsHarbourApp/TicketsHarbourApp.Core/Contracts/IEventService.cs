using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketsHarbourApp.Infrastructure.Data.Domain;

namespace TicketsHarbourApp.Core.Contracts
{
    public interface IEventService
    {
        bool Create(int concertId,int locationId,DateTime beginning, decimal price,  int quantity,decimal discount);

        bool Update(int eventId, int concertId, int locationId, DateTime beginning, decimal price, int quantity, decimal discount);
        bool RemoveById(int eventId);
        List<Event> GetEvents();
        
        Event GetEventById(int eventId);

       
        List<Event> GetEvents(string searchConcertName, string searchLocationName);
    }

}

