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
        List<Concert> GetConcerts();
        Concert GetConcertById(int concertId);
        List<Event> GetEventByConcert(int concertId);


    }
}
