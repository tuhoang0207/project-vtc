using BLL.Interfaces;
using DAL.Entities;
using DAL.UnitOfWork;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class AccountEmployeeService : IAccountEmployeeService
    {
        public IUnitOfWork unitOfWork;
        private int emp_no;
        public AccountEmployeeService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public  bool Attach(AccountEmployee model)
        {
            if(model != null)
            {
                 unitOfWork.AccountEmployeeResository.AttchTEntity(model);
                var result = unitOfWork.SaveChanges();
                if (result > 0)
                    return true;
                return false;
            }
            return false;
        }

        public bool Delete(AccountEmployee model)
        {
            throw new NotImplementedException();
        }

        public AccountEmployee Find(int id)
        {
            throw new NotImplementedException();
        }

        public bool Islogin(string userName, string passWord)
        {
            
            if (userName != null  && passWord != null)
            {
                emp_no =  unitOfWork.AccountEmployeeResository
                    .GetAllAsync()
                    .Where(account => account.UserName == userName && account.PassWord == passWord).FirstOrDefault()
                    .Emp_no;
                if (this.emp_no > 0) return true;
                return false;
            }
            return false;
        }

        public int GetIdForEmp()
        {
            return this.emp_no;
        }

        public IEnumerable<AccountEmployee> GetAll()
        {
           return unitOfWork.AccountEmployeeResository.GetAllAsync();
        }

        public  bool Update(AccountEmployee model)
        {
           if(model != null)
            {
                unitOfWork.AccountEmployeeResository.Update(model);
                var result = unitOfWork.SaveChanges();
                if (result > 0)
                    return true;
             
               return false;
            }
            return false;
        }
    }
}
