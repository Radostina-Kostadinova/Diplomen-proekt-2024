using Microsoft.EntityFrameworkCore.Metadata.Internal;
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
    public class EventService : IEventService
    {
        private readonly ApplicationDbContext _context;

        public EventService(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool Create(int concertId, int locationId, DateTime beginning, decimal price, int quantity, decimal discount)
        {
            Event item = new Event
            {
                Concert = _context.Concerts.Find(concertId),
                Location = _context.Locations.Find(locationId),

                Beginning = beginning,
                Price = price,
                Quantity = quantity,
                Discount = discount,

            };
            _context.Events.Add(item);
            return _context.SaveChanges() != 0;

        }

        public Event GetEventById(int eventId)
        {
            return _context.Events.Find(eventId);
        }

        public List<Event> GetEvents()
        {
            List<Event> events = _context.Events.ToList();
            return events;
        }

        public List<Event> GetEvents(string searchConcertName, string searchLocation)
        {
            List<Event> events = _context.Events.ToList();
            if (!String.IsNullOrEmpty(searchConcertName) && !String.IsNullOrEmpty(searchLocation))
            {
                events = events.Where(x => x.Concert.ConcertName.ToLower().Contains(searchConcertName.ToLower())
                && x.Location.Name.ToLower().Contains(searchLocation.ToLower())).ToList();
            }
            else if (!String.IsNullOrEmpty(searchConcertName))
            {
                events = events.Where(x => x.Concert.ConcertName.ToLower().Contains(searchConcertName.ToLower())).ToList();
            }
            else if (!String.IsNullOrEmpty(searchLocation))
            {
                events = events.Where(x => x.Location.Name.ToLower().Contains(searchLocation.ToLower())).ToList();
            }
            return events;
        }

        public bool RemoveById(int eventId)
        {
            var item = GetEventById(eventId);
            if (item == default(Event))
            {
                return false;
            }
            _context.Remove(item);
            return _context.SaveChanges() != 0;
        }

     
       public bool Update(int eventId, int concertId, int locationId, DateTime beginning, decimal price, int quantity, decimal discount)
        {
            var item = GetEventById(eventId);
            if (item == default(Event))
            {
                return false;
            }
            item.Concert = _context.Concerts.Find(concertId);
            item.Location = _context.Locations.Find(locationId);

            item.Beginning = beginning;
            item.Price=price; 
            item.Quantity=quantity;
            item.Discount=discount;

            _context.Update(item);
            return _context.SaveChanges() != 0;
        }



    }
}
