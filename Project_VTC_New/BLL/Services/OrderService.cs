using DAL.Entities;
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
        public  bool AttachOrder(Order order)
        {
             unitOfWork.Orders.AttchTEntity(order);
            var result = unitOfWork.SaveChanges();
            if (result > 0)
                return true;
            return false;
        }
        public  bool UpdateOrder(Order order)
        {
            unitOfWork.Orders.Update(order);
            var result = unitOfWork.SaveChanges();
            if (result > 0) return true;
            return false;
        }
        public  bool DeleteOrder(Order order)
        {
             unitOfWork.Orders.Delete(order);
            var result = unitOfWork.SaveChanges();
            if (result > 0) return true;
            return false;
        }




        public  Order Find(int order_no)
        {
            return  unitOfWork.Orders.GetAsync(order_no);
        }
        public  IEnumerable<Order> GetListUnpaind()
        {
            return  unitOfWork.Orders.GetUnpaidOrder();
        }
        public  IEnumerable<Order> GetAll()
        {
            return  unitOfWork.Orders.GetAllAsync();
        }
        public  IEnumerable<Order> GetHistoryBill(DateTime since, DateTime toDate)
        {
            return  unitOfWork.Orders.GetHistoryBill(since, toDate);
        }
    }
}
