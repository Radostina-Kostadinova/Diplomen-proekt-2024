﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebShopApp.Core.Contracts;
using WebShopApp.Infrastructure.Data;
using WebShopApp.Infrastructure.Data.Domain;

namespace WebShopApp.Core.Services
{
    public class OrderService : IOrderService
    {
        private readonly ApplicationDbContext _context;
     

        public OrderService(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool Create(int productId, string userId, int quantity)
        {
            //намираме продукта по неговото id
            var product = this._context.Products.SingleOrDefault(x => x.Id == productId);

            //проверяваме дали има  такъв продукт
            if (product == null)
            {
                return false;
            }

            //създаване на поръчка
            Order item = new Order
            {
                OrderDate = DateTime.Now,
                ProductId = productId,
                UserId = userId,
                Quantity = quantity,
                Price = product.Price,
                Discount = product.Discount, 
            };

            //намаляване на количеството на продукта
            product.Quantity -= quantity;

            //отразяване на промените в колекциите
            this._context.Products.Update(product);
            this._context.Orders.Add(item);

            //запис на промените в БД
            return _context.SaveChanges() != 0;
        }

        public Order GetOrderById(int orderId)
        {
            throw new NotImplementedException();
        }

        public List<Order> GetOrders()
        {
            return _context.Orders.OrderByDescending(x=>x.OrderDate).ToList();
        }

        public List<Order> GetOrdersByUser(string userId)
        {
            return _context.Orders.Where(x=>x.UserId == userId)
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
