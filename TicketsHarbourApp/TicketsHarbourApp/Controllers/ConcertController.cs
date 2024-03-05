using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TicketsHarbourApp.Core.Contracts;
using TicketsHarbourApp.Infrastructure.Data.Domain;
using TicketsHarbourApp.Models.Concert;

namespace TicketsHarbourApp.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class ConcertController : Controller
    {
        private readonly IConcertService _concertService;

        public ConcertController(IConcertService concertService)
        {
            this._concertService = concertService;
        }


        // GET: ConcertController
        [AllowAnonymous]
        //da go mahna li tozi atribut i nad Details???
        public ActionResult Index()
        {
            List<ConcertIndexVM> concerts = _concertService.GetConcerts()
                .Select(concerts => new ConcertIndexVM
                {
                    Id = concerts.Id,
                    ConcertName = concerts.ConcertName,
                    Performers=concerts.Performers,
                    Description=concerts.Description,
                    Picture=concerts.Picture
                
                }).ToList();
            return this.View(concerts);
        }


        // GET: ConcertController/Details/5
        [AllowAnonymous]
        public ActionResult Details(int id)
        {
            Concert item = _concertService.GetConcertById(id);
            if (item == null)
            {
                return NotFound();
            }
            ConcertDetailsVM concert = new ConcertDetailsVM()
            {
                Id = item.Id,
                ConcertName = item.ConcertName,
                Performers = item.Performers,
                Description = item.Description,
                Picture = item.Picture
            };
            return View(concert);
        }



        // GET: ConcertController/Create
        public ActionResult Create()
        {
            return View();
        }



        // POST: ConcertController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([FromForm] ConcertCreateVM concert)
        {
            if (ModelState.IsValid)
            {
                var createdId = _concertService.Create(concert.ConcertName, concert.Performers, concert.Description,
               concert.Picture);

                if (createdId)
                {
                    return RedirectToAction(nameof(Index));
                }
            }

            return View();
        }

        // GET: ConcertController/Edit/5
        public ActionResult Edit(int id)
        {
            Concert concert = _concertService.GetConcertById(id);
            if (concert == null)
            {
                return NotFound();
            }

            ConcertEditVM updatedConcert = new ConcertEditVM()
            {
                Id = concert.Id,
                ConcertName = concert.ConcertName,
                Performers = concert.Performers,
                Description = concert.Description,
                Picture = concert.Picture
            };
            return View(updatedConcert);
        }




        // POST: ConcertController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ConcertEditVM concert)
        {
            if (ModelState.IsValid)
            {
                var updated = _concertService.Update(id, concert.ConcertName, concert.Performers,
                                                   concert.Description, concert.Picture);
                if (updated)
                {
                    return this.RedirectToAction("Index");
                }

            }
            return View(concert);
        }







        // GET: ConcertController/Delete/5
        public ActionResult Delete(int id)
        {
            Concert item = _concertService.GetConcertById(id);
            if (item == null)
            {
                return NotFound();
            }
            ConcertDeleteVM concert = new ConcertDeleteVM()
            {
                Id = item.Id,
                ConcertName = item.ConcertName,
                Performers = item.Performers,
                Description = item.Description,
                Picture = item.Picture
            };
            return View(concert);
        }

        // POST: ConcertController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            var deleted = _concertService.RemoveById(id);

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

            return View();
        }
       
        //trqbva li mi success


    }
}
