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
    public class CustomerService : ICustomerService
    {
        public IUnitOfWork unitOfWork;
        public CustomerService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public  bool Attach(Customer customer)
        {
            if(customer != null)
            {
                unitOfWork.Customers.AttchTEntity(customer);
                var result = unitOfWork.SaveChanges();
                if(result > 0) return true;
                return false;
            }
            return false;
        }
        public  bool Update(Customer customer)
        {
            if(customer != null)
            {
                var resultCustomer =  unitOfWork.Customers.GetAsync(customer.Cus_no);
                if(resultCustomer != null)
                {
                      unitOfWork.Customers.Update(customer);
                    var result = unitOfWork.SaveChanges();
                    if (result > 0) return true;
                    return false;
                }
            }
            return false;
        }
        public  bool Delete(Customer customer)
        {
            if(customer != null)
            {
                var resultCustomer =  unitOfWork.Customers.GetAsync(customer.Cus_no);
                if (resultCustomer != null)
                {
                     unitOfWork.Customers.Delete(customer);
                    var result = unitOfWork.SaveChanges();
                    if (result > 0) return true;
                    return false;
                }
            }
            return false;
        }
        public  Customer Find(int cus_no)
        {
            return  unitOfWork.Customers.GetAsync(cus_no);
        }
        public  IEnumerable<Customer> GetAll()
        {
            return  unitOfWork.Customers.GetAllAsync();
        }
    }
}
