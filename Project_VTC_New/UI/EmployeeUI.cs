using BLL.Interfaces;
using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI
{
    public class EmployeeUI
    {
        private IAccountEmployeeService accountEmployeeService;
        private IEmployeeService employeeService;
        public EmployeeUI(IAccountEmployeeService accountEmployeeService, IEmployeeService employeeService)
        {
            this.accountEmployeeService = accountEmployeeService;
            this.employeeService = employeeService;
        }
        public   void AttachEmployee()
        {
            AccountEmployee account_Emp = new AccountEmployee();
            Console.Write("User name: ");
            account_Emp.UserName = Console.ReadLine();
            Console.Write("PassWord: ");
            account_Emp.PassWord = Console.ReadLine();
            account_Emp.Emp_st = 0;
            Employee employee = new Employee();
            employee.Emp_no = account_Emp.Emp_no;
            Console.Write("Enter last name: ");
            employee.Last_name = Console.ReadLine();
            Console.Write("Enter first name: ");
            employee.First_name = Console.ReadLine();
            Console.Write("Enter phone number: ");
            employee.PhoneNumber = Console.ReadLine();
            if (this.accountEmployeeService.Attach(account_Emp))
            {
                  this.employeeService.Attach(employee);
                Console.WriteLine("Successfully");
                return;
            }
            Console.WriteLine("Error");
        }
        public   void GetListAccountEmployee()
        {
            var listAccount_Emp =   this.accountEmployeeService.GetAll();
            Console.WriteLine("+----------------------------------------------+");
            Console.WriteLine("|ID       |Username     |Password   |Status    |");
            Console.WriteLine("|----------------------------------------------|");
            foreach (var item in listAccount_Emp)
            {
                string empStr;
                empStr = item.Emp_st == 1 ? "locked" : "active";
                 
                Console.WriteLine($"{item.Emp_no,-5}|{item.UserName,-30}|{item.PassWord,10}|{item.Emp_st}");
                Console.WriteLine("+-----+------------------------------+------+");
            }
        }
        public   void ShowInformationEmployee(int emp_no)
        {
            var empInformation =   this.employeeService.Find(emp_no);

            Console.WriteLine("+-----------------------------------------------------------+");
            Console.WriteLine("|ID       |Last Name          |First Name                    |Phone Number|");
            Console.WriteLine("|-----------------------------------------------------------|");
            Console.WriteLine($"{empInformation.Emp_no,-5}|{empInformation.Last_name,-20}|" +
                $"{empInformation.First_name,-30}|{empInformation.PhoneNumber}");
            Console.WriteLine("+-----+------------------------------+----------+");
        }

    }
}
