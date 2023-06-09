﻿using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IOrderRepository : IGenericRepository<Order>
    {
        IEnumerable<Order> GetHistoryBill(DateTime since, DateTime toDate);
        IEnumerable<Order> GetUnpaidOrder();

    }
}
