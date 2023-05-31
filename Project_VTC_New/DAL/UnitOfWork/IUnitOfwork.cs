using DAL.Interfaces;



namespace DAL.UnitOfWork
{
    public interface IUnitOfWork :IDisposable
    {
        IAccountAdminReposioty accountAdminReposioty { get; }
        IEmployeeRepository EmployeeRepository { get; }
        IAccountEmployeeResository AccountEmployeeResository { get; }
        ISalaryRepository SalaryRepository { get; }
        ICustomerRepository Customers { get; }
        ICategoryRepository Categories { get; }
        IProductRepository Products { get; }
        ITableRepository Tables { get; }
        IOrderRepository Orders { get; }
        IOrderDetailRepository OrderDetails { get; }
    
        int SaveChanges();
    }
}
