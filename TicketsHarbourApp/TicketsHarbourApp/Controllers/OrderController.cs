using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using System.Security.Claims;
using TicketsHarbourApp.Core.Contracts;
using TicketsHarbourApp.Infrastructure.Data.Domain;
using TicketsHarbourApp.Models.Order;

namespace TicketsHarbourApp.Controllers
{
    [Authorize]
    public class OrderController: Controller
    {
        private readonly IEventService _eventService;
        private readonly IOrderService _orderService;

        public OrderController(IEventService eventService, IOrderService orderService)
        {
            _eventService = eventService;
            _orderService = orderService;
        }



        // GET: OrderController/Create
        public ActionResult Create(int id)
        {
            Event item = _eventService.GetEventById(id);
            if (item == null)
            {
                return NotFound();
            }

            OrderCreateVM order = new OrderCreateVM()
            {
                EventId = item.Id,
                EventName=item.Concert.ConcertName,
                QuantityInStock = item.Quantity,
                Price = item.Price,
                Discount = item.Discount,
                Picture=item.Concert.Picture,
                
            };

            return View(order);

        }





        // POST: OrderController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(OrderCreateVM bindingModel)
        {
            string currentUserId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

            var item = this._eventService.GetEventById(bindingModel.EventId);
            if (currentUserId == null || item == null || item.Quantity < bindingModel.Quantity ||
                item.Quantity == 0)
            {
                return RedirectToAction("Denied", "Order");
            }


            if (ModelState.IsValid)
            {
                _orderService.Create(bindingModel.EventId, currentUserId, bindingModel.Quantity);
            }
            return this.RedirectToAction("Index", "Event");
        }

        //Get:OrderController/Denied
        public ActionResult Denied()
        {
            return View();
        }

    
            // GET: OrderController
        [Authorize(Roles = "Administrator")]
        public ActionResult Index()
        {
            // string userId = this.User. FindFirstValue (ClaimTypes.NameIdentifier);
            // var user = context.Users.SingleOrDefault (u => u.Id == userId);

            List<OrderIndexVM> orders = _orderService.GetOrders()
            .Select(x => new OrderIndexVM
        {
                Id = x.Id,               
                UserId = x.UserId,
                User = x.User.UserName,
                EventId = x.EventId,
                Event=x.Event.Concert.ConcertName,
                Picture= x. Event.Concert.Picture,
                OrderDate = x.OrderDate.ToString("dd-MMM-yyyy hh:mm", CultureInfo.InvariantCulture),
                Quantity = x.Quantity,
                Price =x. Price,
                Discount= x. Discount,
                TotalPrice = x.TotalPrice,
                 }) .ToList();
            return View(orders);
        }




        public ActionResult MyOrders()
        {
            string currentUserId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            // var user = context.Users.SingleOrDefault (u=> u. Id == userId);

            List<OrderIndexVM> orders = _orderService.GetOrdersByUser(currentUserId)
        .Select(x => new OrderIndexVM
        {
            Id = x.Id,
            UserId = x.UserId,
            User = x.User.UserName,
            EventId = x.EventId,
            //Event = x.Event.Name
            //Picture= x. Event.Picture,
            OrderDate = x.OrderDate.ToString("dd-MMM-yyyy hh:mm", CultureInfo.InvariantCulture),
            Quantity = x.Quantity,
            Price = x.Price,
            Discount = x.Discount,
            TotalPrice = x.TotalPrice,
        }).ToList();
            return View(orders);
        }

        


    }
}
