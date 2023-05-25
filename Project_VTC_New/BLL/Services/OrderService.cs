﻿using DAL.Entities;
using DAL.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class OrderService
    {
        public IUnitOfWork unitOfWork;
        public OrderService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task<bool> AttachOrder(Order order)
        {
            await unitOfWork.Orders.AttchTEntity(order);
            var result = unitOfWork.SaveChanges();
            if (result > 0)
                return true;
            return false;
        }
        public async Task<bool> UpdateOrder(Order order)
        {
            unitOfWork.Orders.Update(order);
            var result = unitOfWork.SaveChanges();
            if (result > 0) return true;
            return false;
        }
        public async Task<bool> DeleteOrder(Order order)
        {
             unitOfWork.Orders.Delete(order);
            var result = unitOfWork.SaveChanges();
            if (result > 0) return true;
            return false;
        }




        public async Task<Order> Find(int order_no)
        {
            return await unitOfWork.Orders.GetAsync(order_no);
        }
        public async Task<IEnumerable<Order>> GetListUnpaind()
        {
            return await unitOfWork.Orders.GetUnpaidOrder();
        }
        public async Task<IEnumerable<Order>> GetAll()
        {
            return await unitOfWork.Orders.GetAllAsync();
        }
        public async Task<IEnumerable<Order>> GetHistoryBill(DateTime since, DateTime toDate)
        {
            return await unitOfWork.Orders.GetHistoryBill(since, toDate);
        }
    }
}
