using BLL.Interfaces;
using DAL.Entities;
using DAL.UnitOfWork;
using MySqlX.XDevAPI.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class OrderDetailService : IOrderDetailService
    {
        public IUnitOfWork unitOfWork;
        public OrderDetailService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public bool Attach(OrderDetail entity)
        {
            unitOfWork.OrderDetails.AttchTEntity(entity); return true;
        }
    }
}
