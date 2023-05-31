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
        public  bool Attach(Product model)
        {
            if (model != null)
            {
                 unitOfWork.Products.AttchTEntity(model);
                var result = unitOfWork.SaveChanges();
                if (result > 0) return true;
                return false;
            }
            return false;
        }

        public  bool Update(Product model)
        {
            if (model != null)
            {
                 unitOfWork.Products.Update(model);
                unitOfWork.SaveChanges();
                return true;
            }
            return false;
        }

        public bool Delete(Product model)
        {
            throw new NotImplementedException();
        }

        public  IEnumerable<Product> GetAll()
        {
            return  unitOfWork.Products.GetAllAsync();
        }

        public  IEnumerable<Product> GetListProductByName(string productName)
        {
            var result =  unitOfWork.Products.GetAllAsync();
            return result.Where(x =>x.Prod_name.Contains(productName));
        }

        public Product Find(int id)
        {
            throw new NotImplementedException();
        }
    }
}
