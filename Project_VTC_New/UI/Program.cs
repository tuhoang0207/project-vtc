// See https://aka.ms/new-console-template for more information

using System.Runtime.CompilerServices;
using BLL.Interfaces;
using BLL.Services;
using DAL.Entities;
using DAL.UnitOfWork;
using UI;

namespace UI
{
    class Program
    {
        private  delegate void FucntionMenu(ProductUI productUi, OrderUI orderUi, CustomerUI customerUi,
            EmployeeUI employeeUi);

        private delegate void FucntionMenuEmp(ProductUI productUi, OrderUI orderUi, CustomerUI customerUi);

        private static FucntionMenu FucntionMenuDelegate;
        private static FucntionMenuEmp FucntionMenuEmployee;
        static void Main(string[] agrs)
        {
            UnitOfWork unitOfWork = new UnitOfWork();
            
            //Service
            #region Create Service

            AccountAdminService accountAdminService = new AccountAdminService(unitOfWork);
            AccountEmployeeService accountEmployeeService = new AccountEmployeeService(unitOfWork);
            EmployeeService employeeService = new EmployeeService(unitOfWork);
            ProductService productService = new ProductService(unitOfWork);
            
            CategoryService categoryService = new CategoryService(unitOfWork);
            TableService tableService = new TableService(unitOfWork);
            CustomerService customerService = new CustomerService(unitOfWork);
            OrderDetailService orderDetailService = new OrderDetailService(unitOfWork);
            #endregion



            //UI
            CustomerUI customerUI = new CustomerUI(customerService);
            EmployeeUI employeeUI = new EmployeeUI(accountEmployeeService, employeeService);
            ProductUI productUI = new ProductUI(categoryService, productService);
            LoginAccount loginAccount = new LoginAccount(accountAdminService, accountEmployeeService);
            OrderUI orderUI =  new OrderUI(unitOfWork, tableService, productService, orderDetailService);

            FucntionMenuDelegate = MenuAdmin;
            FucntionMenuEmployee = MenuEmployee;
           
            loginAccount.Menu();
            if (loginAccount.IsLogin())
            {
                if (AccountManager.Instance.AccountAdmin())
                {
                    FucntionMenuDelegate(productUI, orderUI, customerUI, employeeUI);
                }

                if (AccountManager.Instance.AccountEmployee())
                {
                    FucntionMenuEmployee(productUI, orderUI, customerUI);
                }
            }
        }

        static void MenuEmployee(ProductUI productUi, OrderUI orderUi, CustomerUI customerUi)
        {
            int choice = 0;
            do
            {
                Console.WriteLine("+-------------------+");
                Console.WriteLine("|1. Product Manager |");
                Console.WriteLine("|-------------------|");
                Console.WriteLine("|2. Order Manager   |");
                Console.WriteLine("|-------------------|");
                Console.WriteLine("|3. Customer Manager|");
                Console.WriteLine("|-------------------|");
                Console.WriteLine("|0. Exit            |");
                Console.WriteLine("+-------------------+");
                switch (choice)
                {
                    case 0:
                        Console.WriteLine("Good Bye");
                        break;
                    case 1:
                        productUi.Menu();
                        break;
                    case 2:
                        orderUi.Menu();
                        break;
                    case 3:
                        customerUi.Menu();
                        break;
                }
            } while (choice != 0);
            
        }
        
        static void MenuAdmin(ProductUI productUi, OrderUI orderUi, CustomerUI customerUi,EmployeeUI employeeUi)
        {
            int choice = 0;
            do
            {
                
            } while (choice != 0);
            Console.WriteLine("+-------------------+");
            Console.WriteLine("|1. Product Manager |");
            Console.WriteLine("|-------------------|");
            Console.WriteLine("|2. Order Manager   |");
            Console.WriteLine("|-------------------|");
            Console.WriteLine("|3. Employee Manager|");
            Console.WriteLine("|-------------------|");
            Console.WriteLine("|4. Customer Manager|");
            Console.WriteLine("|-------------------|");
            Console.WriteLine("|0. Exit            |");
            Console.WriteLine("+-------------------+");
        }
    }
}

