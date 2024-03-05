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
    public class LocationService : ILocationService
    {

        private readonly ApplicationDbContext _context;

        public LocationService(ApplicationDbContext context)
        {
            _context = context;
        }
        public List<Location> GetLocations()
        {
            List<Location> locations = _context.Locations.ToList();
            return locations;
        }
        public Location GetLocationById(int locationId)
        {
            return _context.Locations.Find(locationId);
        }

        public List<Event> GetEventByLocation(int locationId)
        {
            return _context.Events
                  .Where(x => x.LocationId == locationId)
              .ToList();
        }

       

       


    }
}
