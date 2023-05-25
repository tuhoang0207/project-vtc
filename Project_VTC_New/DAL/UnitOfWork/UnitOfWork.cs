using DAL.Interfaces;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        public ICustomerRepository Customers { get;private set; }
        public ICategoryRepository Categories { get;private set; }
        public IProductRepository Products { get;private set; }
        public ITableRepository Tables { get;private set; }
        public IOrderRepository Orders { get;private set; }
        public IOrderDetailRepository OrderDetails { get;private set; }



        private readonly CoffeeShopDbContext context;
        public UnitOfWork()
        {
            this.context = new CoffeeShopDbContext();
            this.Customers = new CustomerRepository(context);
            this.Categories = new CategoryRepository(context);
            this.Products = new ProductRepository(context);
            this.Orders = new OrderRepository(context);
            this.OrderDetails = new OrderDetailRepository(context);
            this.Tables = new TableRepository(context);
        }



        public int SaveChanges()
        {
            return this.context.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        public virtual void Dispose(bool disposing)
        {
            if(disposing)
            {
                context.Dispose();
            }
        }

        public void RollBack()
        {
            throw new NotImplementedException();
        }
        public void Commit()
        {
            throw new NotImplementedException();
        }
    }
}
