using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.UnitOfWork
{
    public interface IUnitOfWork :IDisposable
    {
        IEmployeeRepository EmployeeRepository { get; }
        IAccountEmployeeResository AccountEmployeeResository { get; }
        ISalaryRepository SalaryRepository { get; }
        ICustomerRepository Customers { get; }
        ICategoryRepository Categories { get; }
        IProductRepository Products { get; }
        ITableRepository Tables { get; }
        IOrderRepository Orders { get; }
        IOrderDetailRepository OrderDetails { get; }
        void RollBack();
        void Commit();
        int SaveChanges();
    }
}
