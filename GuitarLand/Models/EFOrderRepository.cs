﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

using System.Threading.Tasks;

namespace GuitarLand.Models
{
    public class EFOrderRepository : IOrderRepository
    {
        private ApplicationDbContext context;

        public EFOrderRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }

        public IQueryable<Order> Orders => context.Orders
            .Include(o => o.Lines)
            .ThenInclude(l => l.Product);

        public void SaveOrder(Order order)
        {
            context.AttachRange(order.Lines.Select(l => l.Product));
            if (order.OrderID == 0)
            {
                context.Orders.Add(order);
            }
            context.SaveChanges();
        }

        public Order DeleteOrder(int orderID)
        {
            Order dbEntry = context.Orders
                .FirstOrDefault(o => o.OrderID == orderID);

            
            if (dbEntry != null)
            {

                context.Orders.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }
    }
}
