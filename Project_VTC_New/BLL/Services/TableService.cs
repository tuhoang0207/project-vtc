using BLL.Interfaces;
using DAL.Entities;
using DAL.UnitOfWork;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class TableService : ITableService
    {
        public IUnitOfWork unitOfWork;
        public TableService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task<bool> Attach(Table model)
        {
            if (model !=null)
            {
                await this.unitOfWork.Tables.AttchTEntity(model);
                var result = unitOfWork.SaveChanges();
                if(result > 0)
                    return true;
                return false;
            }
            return false;
        }
        public async Task<Table> Find(int id)
        {
           return await this.unitOfWork.Tables.GetAsync(id);
        }

        public async Task<IEnumerable<Table>> GetAll()
        {
            return await this.unitOfWork.Tables.GetAllAsync();
        }
        public Task<bool> Delete(Table model)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(Table model)
        {
            throw new NotImplementedException();
        }
    }
}
