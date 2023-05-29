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
        bool Attach(Employee employee);
        bool Update(Employee employee);
        Employee Find(int emp_no);
    }
}
