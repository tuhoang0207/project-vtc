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
        public  bool Attach(Table model)
        {
            if (model !=null)
            {
                 this.unitOfWork.Tables.AttchTEntity(model);
                var result = unitOfWork.SaveChanges();
                if(result > 0)
                    return true;
                return false;
            }
            return false;
        }
        public  Table Find(int id)
        {
           return  this.unitOfWork.Tables.GetAsync(id);
        }

        public  IEnumerable<Table> GetAll()
        {
            return  this.unitOfWork.Tables.GetAllAsync();
        }
        public bool Delete(Table model)
        {
            throw new NotImplementedException();
        }

        public bool Update(Table model)
        {
            throw new NotImplementedException();
        }
    }
}
