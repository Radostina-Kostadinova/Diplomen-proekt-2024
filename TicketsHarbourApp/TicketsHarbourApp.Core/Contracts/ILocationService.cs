using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketsHarbourApp.Infrastructure.Data.Domain;

namespace TicketsHarbourApp.Core.Contracts
{
    public interface ILocationService
    {
        List<Location> GetLocations();
        Location GetLocationById(int locationId);
        List<Event> GetEventByLocation(int locationId);

    }
}
