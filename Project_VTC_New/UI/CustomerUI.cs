using BLL.Interfaces;
using BLL.Services;
using DAL.Entities;
using DAL.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI
{
    public class CustomerUI
    {
        private ICustomerService customerService;
        public CustomerUI(IUnitOfWork unitOfWork, ICustomerService customerService)
        {
            this.customerService = customerService;
        }

        public void Menu()
        {
            int choose;
            do
            {
                Console.WriteLine("+--------------------+");
                Console.WriteLine("|1. Attach Customer  |");
                Console.WriteLine("|--------------------|");
                Console.WriteLine("|2. Update Customer  |");
                Console.WriteLine("+--------------------+");

                choose = Convert.ToInt32(Console.ReadLine());
                switch (choose)
                {
                    case 0:
                        {

                            break;
                        }
                    case 1:
                        {
                            //AttchOrder();
                            break;
                        }
                    case 2:
                        {

                            break;
                        }
                }

            } while (choose != 0);
        }
        public async void AttachCustomer()
        {
            Customer customer = new Customer();
            Console.Write("Enter last name customer: ");
            customer.Last_name = Console.ReadLine();
            Console.Write("Enter first name customer: ");
            customer.First_name = Console.ReadLine();
            Console.Write("Enter phone number customer: ");
            customer.PhoneNumber = Console.ReadLine();
            customer.Cus_st = 0;
            var result = await this.customerService.Attach(customer);
            if(result == true )
            {
                Console.WriteLine("Successfully");
                return;
            }
            Console.WriteLine("Error");
        }
        public async void UpdateCustomer()
        {
            Console.Write("Enter ID customer: ");
            int cus_no = Convert.ToInt32(Console.ReadLine());
            var result = await customerService.Find(cus_no);
            if(result != null )
            {
                Console.Write("Enter last name: ");
                result.Last_name = Console.ReadLine();
            }

        }
        
    }
}
