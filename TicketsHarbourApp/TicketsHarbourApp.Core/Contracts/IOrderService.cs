﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketsHarbourApp.Infrastructure.Data.Domain;

namespace TicketsHarbourApp.Core.Contracts
{
    public interface IOrderService
    {
        bool Create(int eventId, string userId, int quantity);
        List<Order> GetOrders();

        List<Order> GetOrdersByUser(string userId);
        Order GetOrderById(int orderId);
        bool RemoveById(int orderId);
        bool Update(int orderId, int eventId, string userId, int quantity);



    }
}
