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
            CategoryService categoryService = new CategoryService(unitOfWork);

            int choose = 0;
            do
            {
                Console.WriteLine("1. Product Manager");
                Console.WriteLine("2. Order Manager");
                Console.WriteLine("3. Employee Manager");
                Console.WriteLine("4. Customer Manaher");
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
                }
            } while (choose != 0);
        }
        static void MenuManager()
        {
            
        }
    }
}

