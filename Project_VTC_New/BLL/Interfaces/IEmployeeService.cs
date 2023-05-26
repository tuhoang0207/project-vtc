using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IEmployeeService 
    {
        Task<bool> Attach(Employee employee);
        Task<bool> Update(Employee employee);
        Task<Employee> Find(int emp_no);
    }
}
