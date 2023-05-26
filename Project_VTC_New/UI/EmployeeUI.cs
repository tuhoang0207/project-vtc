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
        public async void AttachEmployee()
        {
            AccountEmployee account_Emp = new AccountEmployee();
            Console.Write("User name: ");
            account_Emp.UserName = Console.ReadLine();
            Console.Write("PassWork: ");
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
            if (await this.accountEmployeeService.Attach(account_Emp))
            {
                await this.employeeService.Attach(employee);
                Console.WriteLine("Successfully");
                return;
            }
            Console.WriteLine("Error");
        }
        public void GetListAccountEmployee()
        {
            var listtAccount_Emp = this.accountEmployeeService.GetAll();
        }
        public void ShowInformationEmployee(int emp_no)
        {

        }

    }
}
