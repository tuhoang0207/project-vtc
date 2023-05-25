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
        public async Task<bool> Attach(Customer customer)
        {
            if(customer != null)
            {
                await unitOfWork.Customers.AttchTEntity(customer);
                var result = unitOfWork.SaveChanges();
                if(result > 0) return true;
                return false;
            }
            return false;
        }
        public async Task<bool> Update(Customer customer)
        {
            if(customer != null)
            {
                var resultCustomer = await unitOfWork.Customers.GetAsync(customer.Cus_no);
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
        public async Task<bool> Delete(Customer customer)
        {
            if(customer != null)
            {
                var resultCustomer = await unitOfWork.Customers.GetAsync(customer.Cus_no);
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
        public async Task<Customer> Find(int cus_no)
        {
            return await unitOfWork.Customers.GetAsync(cus_no);
        }
        public async Task<IEnumerable<Customer>> GetAll()
        {
            return await unitOfWork.Customers.GetAllAsync();
        }
    }
}
