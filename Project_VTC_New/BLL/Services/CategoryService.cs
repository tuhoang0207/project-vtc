using BLL.Interfaces;
using DAL.Entities;
using DAL.Interfaces;
using DAL.UnitOfWork;
using MySqlX.XDevAPI.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class CategoryService : ICategoryService
    {
        public IUnitOfWork unitOfWork;
        public CategoryService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public  bool Attach(Category category)
        {
            if(category != null)
            {
                unitOfWork.Categories.AttchTEntity(category);
                var reuslt = unitOfWork.SaveChanges();
                if (reuslt > 0) return true;
                return false;
            }
            return false;
        }
        public  bool Update(Category category)
        {
            if (category != null)
            {
                 unitOfWork.Categories.Update(category);
                var result = unitOfWork.SaveChanges();
                if(result > 0) return true;
                else return false;
            }
            return false;
        }
        public  IEnumerable<Category> GetAll()
        {
            return  unitOfWork.Categories.GetAllAsync();
        }
        public  Category GetProductByCategory(int cate_no)
        {
            return  unitOfWork.Categories.GetProductByCategory(cate_no);
        }

        public bool Delete(Category model)
        {
            throw new NotImplementedException();
        }

        public Category Find(int id)
        {
            throw new NotImplementedException();
        }
    }
}
