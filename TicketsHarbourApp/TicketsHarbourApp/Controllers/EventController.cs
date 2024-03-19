using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using TicketsHarbourApp.Core.Contracts;
using TicketsHarbourApp.Infrastructure.Data.Domain;
using TicketsHarbourApp.Models.Concert;
using TicketsHarbourApp.Models.Event;
using TicketsHarbourApp.Models.Location;

namespace TicketsHarbourApp.Controllers
{

    [Authorize(Roles = "Administrator")]

    public class EventController : Controller    //ne raboti,ako vmesto item pishe event
    {
        private readonly IEventService _eventService;
        private readonly IConcertService _concertService;
        private readonly ILocationService _locationService;

        public EventController(IEventService eventService, IConcertService concertService, ILocationService locationService)
        {
            this._eventService = eventService;
            this._concertService = concertService;
            this._locationService = locationService;
        }


        // GET: EventController
        [AllowAnonymous]
        public ActionResult Index(string searchConcertName, string searchLocation)
        {
            List<EventIndexVM> events = _eventService.GetEvents(searchConcertName, searchLocation)
                .Where(item => item.Beginning > DateTime.Now)
                .Select(item => new EventIndexVM
                {
                    Id = item.Id,
                    ConcertName = item.Concert.ConcertName,
                    ConcertId = item.ConcertId,
                    LocationName = item.Location.Name,
                    LocationId = item.LocationId,
                    Beginning= item.Beginning.ToString("dd-MMM-yyyy HH:mm", CultureInfo.InvariantCulture),
                    Price = item.Price,
                    Quantity = item.Quantity,
                    Discount= item.Discount,
                    Picture = item.Concert.Picture
                }).ToList();  
            return this.View(events);
        }


        // GET: EventController/Details/5
        [AllowAnonymous]
        public ActionResult Details(int id)
        {
            Event item = _eventService.GetEventById(id);
            if (item == null)
            {
                return NotFound();
            }
           EventDetailsVM concert = new EventDetailsVM()
            {
               Id = item.Id,
               ConcertName = item.Concert.ConcertName,
               ConcertId = item.ConcertId,
               LocationName = item.Location.Name,
               LocationId = item.LocationId,
               Beginning = item.Beginning.ToString("dd-MMM-yyyy HH:mm", CultureInfo.InvariantCulture),
               Price = item.Price,
               Quantity = item.Quantity,
               Discount = item.Discount,
               Picture = item.Concert.Picture,
               LocationUrl=item.Location.LocationUrl
           };
            return View(concert);
        }
      
        // GET: EventController/Create
        public ActionResult Create()
        {
            var item = new EventCreateVM();
            item.Concerts = _concertService.GetConcerts()
                .Select(x => new ConcertPairVM()
                {
                    Id = x.Id,
                    Name = x.ConcertName
                }).ToList();
            item.Locations = _locationService.GetLocations()
               .Select(x => new LocationPairVM()
               {
                   Id = x.Id,
                   Location = x.Town+ " " + x.Name
               }).ToList();
            item.Beginning = DateTime.ParseExact(DateTime.Now.ToString("yyyy-MM-dd HH:mm"), "yyyy-MM-dd HH:mm", null);
            return View(item);
        }


        // POST: EventController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]       
        //taka li e i zahto ne iska da raboti,ako vmesto item napisha event
        public ActionResult Create([FromForm] EventCreateVM item)
        {
            if (ModelState.IsValid)
            {
                var createdId = _eventService.Create(item.ConcertId, 
                    item.LocationId, 
                    item.Beginning,
                    item.Price, 
                    item.Quantity,
                    item.Discount);
                    if (createdId)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
                return View();
        }


        // GET: EventController/Edit/5
        //ne raboti,ako vmesto item pishe event
        public ActionResult Edit(int id)
        {
            Event item = _eventService.GetEventById(id);
            if (item == null)
            {
                return NotFound();
            }

            EventEditVM updatedEvent = new EventEditVM()
            {
                Id = item.Id,
                ConcertId = item.ConcertId,
                LocationId = item.LocationId,
                Beginning = DateTime.ParseExact(DateTime.Now.ToString("yyyy-MM-dd HH:mm"), "yyyy-MM-dd HH:mm", null),
                Price = item.Price,
                Quantity = item.Quantity,
                Discount = item.Discount
            };
            updatedEvent.Concerts = _concertService.GetConcerts()
            .Select(b => new ConcertPairVM()
            {
                Id = b.Id,
                Name = b.ConcertName
            })
            .ToList();

            updatedEvent.Locations = _locationService.GetLocations()
               .Select(c => new LocationPairVM()
               {
                   Id = c.Id,
                   Location = c.Name
               })
               .ToList();
            return View(updatedEvent);
        }

        // POST: EventController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id,EventEditVM item)
        {
            {
                if (ModelState.IsValid)
                {
                    var updated = _eventService.Update(id, item.ConcertId,item.LocationId,
                                                      item.Beginning = DateTime.ParseExact(DateTime.Now.ToString("yyyy-MM-dd HH:mm"), "yyyy-MM-dd HH:mm", null),
                                                       item.Price,
                                                       item.Quantity, item.Discount);
                    if (updated)
                    {
                        return this.RedirectToAction("Index");
                    }

                }
                return View(item);
            }
        }

        // GET: EventController/Delete/5
        public ActionResult Delete(int id)
        {
            Event item = _eventService.GetEventById(id);
            if (item == null)
            {
                return NotFound();
            }
            EventDeleteVM deletedEvent = new EventDeleteVM()
            {
                Id = item.Id,
                ConcertName = item.Concert.ConcertName,
                ConcertId = item.ConcertId,
                LocationName = item.Location.Name,
                LocationId = item.LocationId,
                Beginning = item.Beginning.ToString("dd-MMM-yyyy HH:mm", CultureInfo.InvariantCulture),
                Price = item.Price,
                Quantity = item.Quantity,
                Discount = item.Discount
            };
            return View(deletedEvent);
        }

        // POST: EventController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            var deleted = _eventService.RemoveById(id);

            if (deleted)
            {
                return this.RedirectToAction("Success");
            }
            else
            {
                return View();
            }
            //napraven e metod RemoveById v services i contracts
        }

        public IActionResult Success()
        {
            //trqbva li mi success
           return View();
        }
       



    }
}
