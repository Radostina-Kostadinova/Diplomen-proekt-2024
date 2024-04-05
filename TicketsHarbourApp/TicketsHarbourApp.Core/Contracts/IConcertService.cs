using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketsHarbourApp.Infrastructure.Data.Domain;

namespace TicketsHarbourApp.Core.Contracts
{
    public interface IConcertService
    {
        bool Create(string concertName, string performers, string description, string Picture);

        bool Update(int concertId, string concertName, string performers, string description, string Picture);

        bool RemoveById(int concertId);
        List<Concert> GetConcerts();
        Concert GetConcertById(int concertId);
        List<Event> GetEventsByConcert(int concertId);
      
    }
}
