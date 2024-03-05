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
    public class OrderService:IOrderService
    {
        private readonly ApplicationDbContext _context;

        public OrderService(ApplicationDbContext context)
        {
            _context = context;
        }

        //podredbata na stoinostite moje da ne suvpadat s tezi v Domain-a
        public bool Create(int eventId, string userId, int quantity)
        {

            var item = this._context.Events.SingleOrDefault(x => x.Id == eventId);

            if (item == null)
            {
                return false;
            }

            Order newOrder = new Order
            {
                EventId = eventId,
                UserId = userId,
                OrderDate = DateTime.Now,
                Quantity = quantity,
                Price = item.Price,
                Discount = item.Discount
            };

            item.Quantity -= quantity;


            this._context.Events.Update(item);
            this._context.Orders.Add(newOrder);

            return _context.SaveChanges() != 0;
        }

        public List<Order> GetOrders()
        {
            return _context.Orders.OrderByDescending(x => x.OrderDate).ToList();
        }


        //taka li trqbva da sa metodite dolu
             public Order GetOrderById(int orderId)
             {
                 throw new NotImplementedException();
             }

             public List<Order> GetOrdersByUser(string userId)
             {

                 return _context.Orders.Where(x => x.UserId == userId)
                 .OrderByDescending(x => x.OrderDate)
                 .ToList();
             }

             public bool RemoveById(int orderId)
             {
                 throw new NotImplementedException();
             }

             public bool Update(int orderId, int productId, string userId, int quantity)
             {
                 throw new NotImplementedException();
             }

            

        }
}
