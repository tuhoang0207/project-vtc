using BLL.Interfaces;
using BLL.Services;
using DAL.Entities;
using DAL.UnitOfWork;
using MySqlX.XDevAPI.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Security.Authentication;
using System.Text;
using System.Threading.Tasks;

namespace UI
{
    public class ProductUI
    {
        private ICategoryService categoryService;
        private IProductService productService;
        public ProductUI( ICategoryService categoryService, IProductService productService)
        {
            this.categoryService = categoryService;
            this.productService = productService;
        }
        public void Menu()
        {
            int choose = 0;
            do
            {
                Console.WriteLine("+-----------+");
                Console.WriteLine("|1. Product |");
                Console.WriteLine("|-----------|");
                Console.WriteLine("|2. Category|");
                Console.WriteLine("+-----------+");
                choose = Convert.ToInt32(Console.ReadLine());
                switch (choose)
                {
                    case 0:
                        {
                            
                            break;
                        }
                    case 1:
                        {
                            ProductManager();
                            break;
                        }
                    case 2:
                        {
                            CategoryManager();
                            break;
                        }
                }

            } while (choose != 0);
        }
        public void ProductManager()
        {
            int choose = 0;
            do
            {
                Console.WriteLine("+-----------------+");
                Console.WriteLine("|1. Attach Product|");
                Console.WriteLine("|-----------------|");
                Console.WriteLine("|2. Update Product|");
                Console.WriteLine("|-----------------|");
                Console.WriteLine("|3. Delete Product|");
                Console.WriteLine("|-----------------|");
                Console.WriteLine("|4. GetListProduct|");
                Console.WriteLine("+-----------------+");

                choose = Convert.ToInt32(Console.ReadLine());
                switch (choose)
                {
                    case 0:
                        {
                            break;
                        }
                        case 1:
                        {
                            if (AccountManager.Instance.AccountAdmin())
                            {
                                AttachProduct();
                            }
                            else
                            {
                                Console.WriteLine("Only admin can use this fucntion");
                            }
                            break;
                        }
                    case 2:
                        {
                            if (AccountManager.Instance.AccountAdmin())
                            {
                                UpdateProduct();
                            }
                            else
                            {
                                Console.WriteLine("Only admin can use this function");
                            }
                            break;
                        }
                    case 3:
                        {
                            if (AccountManager.Instance.AccountAdmin())
                            {
                                
                            }
                            else
                            {
                                Console.WriteLine("Only admin can use this fucntion");
                            }
                            break;
                        }
                    case 4:
                        {
                            GetListProduct();
                            break;
                        }
                }
            } while (choose != 0);
        }
        
        
        #region UI_Product
        public   void AttachProduct()
        {
             GetListCategory();
            Product product = new Product();
            Console.Write("Enter ID category: ");
            product.Cate_no = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter name product: ");
            product.Prod_name = Console.ReadLine();
            Console.Write("Enter price product: ");
            product.Prod_price = Convert.ToDecimal(Console.ReadLine());
            Console.Write("Enter status product: ");
            product.Prod_st = Convert.ToInt32(Console.ReadLine());
            var result =   productService.Attach(product);
            if(result == true)
            {
                Console.WriteLine("Successfully");
                return;
            }
            Console.WriteLine("Error");

        }
        public   void UpdateProduct()
        {

            Console.Write("Enter ID product: ");
            int prod_no = Convert.ToInt32(Console.ReadLine());
            var resultProduct =   productService.Find(prod_no);
            if (resultProduct != null)
            {
                Console.Write("Enter name product: ");
                resultProduct.Prod_name = Console.ReadLine();
                Console.Write("Enter price: ");
                resultProduct.Prod_price = Convert.ToDecimal(Console.ReadLine());
                Console.Write("Enter status: ");
                resultProduct.Prod_st = Convert.ToInt32(Console.ReadLine());
                var result =   productService.Update(resultProduct);
                if (result == true)
                {
                    Console.WriteLine("Successfully");
                    return;
                }
                Console.WriteLine("Error");
            }
        }
        public   void GetListProduct()
        {
            var listProduct =   productService.GetAll();
            ViewProduct(listProduct.ToList());
        }
        public   void GetListProductByCategory()
        {
            var result =   categoryService.GetProductByCategory(1);
            var listProduct = result.Products.ToList();
            Console.WriteLine("+-----------------------------------------------+");
            Console.WriteLine("name category: " + result.Cate_name);
            
            ViewProduct(listProduct);

        }
        public void ViewProduct(List<Product> listProducts)
        {
            Console.WriteLine("+-----------------------------------------------+");
            Console.WriteLine("|ID   |name product                  |price     |");
            Console.WriteLine("|-----|------------------------------|----------|");
            foreach(var product in listProducts)
            {
                Console.WriteLine($"{product.Prod_no,-5}|{product.Prod_name,-30}|{product.Prod_price,10}|");
                Console.WriteLine("+-----+------------------------------+----------+");
            }
            Console.WriteLine("+-----------------------------------------------+");
        }
        #endregion

        #region UI_Category
        public void CategoryManager()
        {
            int choose = 0;
            do
            {
                Console.WriteLine("+------------------+");
                Console.WriteLine("|1. Attach Category|");
                Console.WriteLine("|------------------|");
                Console.WriteLine("|2. Update Category|");
                Console.WriteLine("|------------------|");
                Console.WriteLine("|3. Delete Category|");
                Console.WriteLine("|------------------|");
                Console.WriteLine("|4. GetListCategory|");
                Console.WriteLine("+------------------+");

                choose = Convert.ToInt32(Console.ReadLine());
                switch (choose)
                {
                    case 0:
                        {
                            break;
                        }
                    case 1:
                        {
                            AttachCateogry();
                            break;
                        }
                    case 2:
                        {
                            UpdateCAtegory();
                            break;
                        }
                    case 3:
                        {

                            break;
                        }
                    case 4:
                        {
                            GetListCategory();
                            break;
                        }
                }
            } while (choose != 0);
        }


        public   void AttachCateogry()
        {
            Category category = new Category();
            Console.Write("Enter category name: ");
            category.Cate_name = Console.ReadLine();
            Console.Write("Enter Discription: ");
            category.Cate_Description = Console.ReadLine();
            var result =   categoryService.Attach(category);
            if (result == true)
            {
                Console.WriteLine("Successfully");
                return;
            }
            Console.WriteLine("Error");
        }
        public  void UpdateCAtegory()
        {
            Console.Write("Enter ID product: ");
            int prod_no = Convert.ToInt32(Console.ReadLine());
            var resultCate =   categoryService.Find(prod_no);
            if (resultCate != null)
            {
                Console.Write("Enter name category: ");
                resultCate.Cate_name = Console.ReadLine();
                Console.Write("Enter Description: ");
                resultCate.Cate_Description = Console.ReadLine();
                var result =   categoryService.Update(resultCate);
                if (result == true)
                {
                    Console.WriteLine("Successfully");
                    return;
                }
                Console.WriteLine("Error");
            }
        }
        public   void GetListCategory()
        {
                var listCategories =   categoryService.GetAll();

                  ViewCategory(listCategories);
        }
        public void ViewCategory(IEnumerable<Category> listCategories)
        {
            
                Console.WriteLine("+-------------------------------------------------------------------+");
                Console.WriteLine("|ID   |name category                 |Description                   |");
                Console.WriteLine("|-----|------------------------------|------------------------------|");
                foreach (var category in listCategories)
                {
                    Console.WriteLine($"|{category.Cate_no,-5}|{category.Cate_name,-30}|{category.Cate_Description,-30}|");
                    Console.WriteLine("|-----+------------------------------+------------------------------|");
                }
                Console.WriteLine("+-------------------------------------------------------------------+");
           
        }
        #endregion
    }
}
