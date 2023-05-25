using BLL.Interfaces;
using DAL.Entities;
using DAL.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class EmployeeService : IEmployeeService
    {
        public IUnitOfWork unitOfWork;
        public EmployeeService(UnitOfWork unitOfwork)
        {
            this.unitOfWork = unitOfwork;
        }

        public Task<bool> Attach(Employee model)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(Employee model)
        {
            throw new NotImplementedException();
        }

        public Task<Employee> Find(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Employee>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(Employee model)
        {
            throw new NotImplementedException();
        }
    }
}
