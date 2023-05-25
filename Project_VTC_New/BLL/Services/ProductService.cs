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
    public class ProductService : IProductService
    {
        public IUnitOfWork unitOfWork;
        public ProductService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task<bool> Attach(Product model)
        {
            if (model != null)
            {
                await unitOfWork.Products.AttchTEntity(model);
                var result = unitOfWork.SaveChanges();
                if (result > 0) return true;
                return false;
            }
            return false;
        }

        public async Task<bool> Update(Product model)
        {
            if (model != null)
            {
                 unitOfWork.Products.Update(model);
                unitOfWork.SaveChanges();
                return true;
            }
            return false;
        }

        public Task<bool> Delete(Product model)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Product>> GetAll()
        {
            return await unitOfWork.Products.GetAllAsync();
        }

        public async Task<IEnumerable<Product>> GetListProductByName(string productName)
        {
            var result = await unitOfWork.Products.GetAllAsync();
            return result.Where(x =>x.Prod_name.Contains(productName));
        }

        public Task<Product> Find(int id)
        {
            throw new NotImplementedException();
        }
    }
}
