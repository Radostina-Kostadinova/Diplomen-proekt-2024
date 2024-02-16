using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketsHarbourApp.Core.Contracts;
using TicketsHarbourApp.Infastructure.Data;
using TicketsHarbourApp.Infrastructure.Data.Domain;

namespace TicketsHarbourApp.Core.Services
{
    public class ConcertService : IConcertService
    {
        private readonly ApplicationDbContext _context;

        public ConcertService(ApplicationDbContext context)
        {
            _context = context;
        }

     
        public List<Concert> GetConcerts()
        {
            List<Concert> concerts = _context.Concerts.ToList();
            return concerts;
        }
        Concert IConcertService.GetConcertById(int concertId)
        {
            return _context.Concerts.Find(concertId);
        }

        public List<Event> GetEventByConcert(int concertId)
        {
            return _context.Events
               .Where(x => x.ConcertId == concertId)
              .ToList();
        }

       


    }
}
