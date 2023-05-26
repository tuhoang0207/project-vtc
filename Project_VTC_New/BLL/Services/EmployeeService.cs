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

        public async Task<bool> Attach(Employee employee)
        {
           if(employee != null)
            {
                await unitOfWork.EmployeeRepository.AttchTEntity(employee);
                var result = unitOfWork.SaveChanges();
                if(result > 0)
                    return true;
                return false;
            }
           return false;
        }

        public async Task<bool> Update(Employee employee)
        {
            if(employee != null)
            {
                unitOfWork.EmployeeRepository.Update(employee);
                var result = unitOfWork.SaveChanges();
                if(result > 0) return true; 
                return false;
            }
            return false;
        }
    }
}
