using DAL.Entities;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class OrderDetailRepository : GenericRepository<OrderDetail>, IOrderDetailRepository
    {
        public OrderDetailRepository(CoffeeShopDbContext context) : base(context)
        {
        }
        public override  Task AttchTEntity(OrderDetail entity)
        {
             entities.FromSqlRaw($"CALL USP_OrderDetail({0},{1},{2})", entity.Order_no, entity.Prod_no, entity.Amount);
            return base.AttchTEntity(entity);
        }
    }
}
