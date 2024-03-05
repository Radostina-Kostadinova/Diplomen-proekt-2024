﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketsHarbourApp.Core.Contracts;
using TicketsHarbourApp.Infastructure.Data;

namespace TicketsHarbourApp.Core.Services
{
    public class StatisticService:IStatisticService
    {

        private readonly ApplicationDbContext _context;
        public StatisticService(ApplicationDbContext context)
        {
            _context = context;
        }


        public int CountClients()
        {
            return _context.Users.Count() - 1;
        }

        public int CountOrders()
        {
            return _context.Orders.Count();
        }

        public int CountEvents()
        {
            return _context.Events.Count();
        }

        public decimal SumOrders()
        {


            var suma = _context.Orders.Sum(x => x.Quantity * x.Price - x.Quantity * x.Price *
                x.Discount / 100);
            return suma;
        }

        


    }
}
