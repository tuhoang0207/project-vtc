using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IAccountEmployeeService : IService<AccountEmployee>
    {
        bool Islogin(string userName, string passWord);
    }
}
