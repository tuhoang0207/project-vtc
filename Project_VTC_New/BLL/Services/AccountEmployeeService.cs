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
        public AccountEmployeeService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task<bool> Attach(AccountEmployee model)
        {
            if(model != null)
            {
                await unitOfWork.AccountEmployeeResository.AttchTEntity(model);
                var result = unitOfWork.SaveChanges();
                if (result > 0)
                    return true;
                return false;
            }
            return false;
        }

        public Task<bool> Delete(AccountEmployee model)
        {
            throw new NotImplementedException();
        }

        public Task<AccountEmployee> Find(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<AccountEmployee>> GetAll()
        {
           return unitOfWork.AccountEmployeeResository.GetAllAsync();
        }

        public async Task<bool> Update(AccountEmployee model)
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
