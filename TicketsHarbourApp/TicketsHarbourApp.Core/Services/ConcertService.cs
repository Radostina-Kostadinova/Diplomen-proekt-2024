using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
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

        public bool Create(string concertName, string performers, string description, string Picture)
        {
            Concert item = new Concert
            {
                ConcertName = concertName,
                Performers = performers,    
                Description = description,
                Picture = Picture
            };
            _context.Concerts.Add(item);
            return _context.SaveChanges() != 0;
        }

        public bool Update(int concertId, string concertName, string performers, string description, string Picture)
        {
            var concert = GetConcertById(concertId);
            if (concert == default(Concert))
            {
                return false;
            }

            concert.ConcertName = concertName;
            concert.Performers = performers;
            concert.Description = description;
            concert.Picture = Picture;

            _context.Update(concert);
            return _context.SaveChanges() != 0;

        }

        public List<Concert> GetConcerts()
        {
            List<Concert> concerts = _context.Concerts.ToList();
            return concerts;
        }
        Concert GetConcertById(int concertId)
        {
            return _context.Concerts.Find(concertId);
        }

        public List<Event> GetEventsByConcert(int concertId)
        {
            return _context.Events
               .Where(x => x.ConcertId == concertId)
              .ToList();
        }

        Concert IConcertService.GetConcertById(int concertId)
        {
            return _context.Concerts.Find(concertId);
        }



        //NOVO RemoveById 
        public bool RemoveById(int concertId)
        {
            var concert = GetConcertById(concertId);
            if (concert == default(Concert))
            {
                return false;
            }
            _context.Remove(concert);
            return _context.SaveChanges() != 0;
        }


    }
}
