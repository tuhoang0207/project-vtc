using DAL.Entities;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
        public OrderRepository(CoffeeShopDbContext context) : base(context)
        {
        }


        public  async Task<IEnumerable<Order>> GetUnpaidOrder()
        {
            return await entities.Where(order => order.Order_st == 0).ToListAsync();
        }

        public  async Task<IEnumerable<Order>> GetHistoryBill(DateTime since, DateTime toDate)
        {
            return await entities
                .Include(order => order.Details)
                .ThenInclude(detail => detail.Product)
                .Where(order => order.CheckOut >= since && order.CheckOut <= toDate).ToArrayAsync();
        }
    }
}
