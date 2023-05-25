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
        public async Task<bool> Attach(Category category)
        {
            if(category != null)
            {
                await unitOfWork.Categories.AttchTEntity(category);
                var reuslt = unitOfWork.SaveChanges();
                if (reuslt > 0) return true;
                return false;
            }
            return false;
        }
        public async Task<bool> Update(Category category)
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
        public async Task<IEnumerable<Category>> GetAll()
        {
            return await unitOfWork.Categories.GetAllAsync();
        }
        public async Task<Category> GetProductByCategory(int cate_no)
        {
            return await unitOfWork.Categories.GetProductByCategory(cate_no);
        }

        public Task<bool> Delete(Category model)
        {
            throw new NotImplementedException();
        }

        public Task<Category> Find(int id)
        {
            throw new NotImplementedException();
        }
    }
}
