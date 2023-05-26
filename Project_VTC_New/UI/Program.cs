// See https://aka.ms/new-console-template for more information
using BLL.Services;
using DAL.UnitOfWork;
using UI;

namespace UI
{
    class Program
    {
        static void Main(string[] agrs)
        {
            UnitOfWork unitOfWork = new UnitOfWork();
            ProductService productService = new ProductService(unitOfWork);
            OrderService orderService = new OrderService(unitOfWork);
            CategoryService categoryService = new CategoryService(unitOfWork);
            TableService tableService = new TableService(unitOfWork);
            CustomerService customerService = new CustomerService(unitOfWork);
            OrderDetailService orderDetailService = new OrderDetailService(unitOfWork);

            new OrderUI(;
            int choose = 0;
            do
            {
                Console.WriteLine("+-------------------+");
                Console.WriteLine("|1. Product Manager |");
                Console.WriteLine("|-------------------|");
                Console.WriteLine("|2. Order Manager   |");
                Console.WriteLine("|-------------------|");
                Console.WriteLine("|3. Employee Manager|");
                Console.WriteLine("|-------------------|");
                Console.WriteLine("|4. Customer Manager|");
                Console.WriteLine("+-------------------+");
                Console.Write("Enter Choose Option: ");
                choose = Convert.ToInt32(Console.ReadLine());
                switch (choose)
                {
                    case 0:
                        {
                            break;
                        }
                    case 1:
                        {
                            new ProductUI(unitOfWork, categoryService,productService).Menu();
                            break;
                        }
                        break;
                    case 2:
                        {
                           
                        }
                        break;
                    case 3:
                        {
                            new CustomerUI(customerService).Menu;
                        }
                        break;
                }
            } while (choose != 0);
        }
        static void MenuManager()
        {
            
        }
    }
}

