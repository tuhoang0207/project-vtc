
using BLL.Interfaces;
using BLL.Services;
using DAL.Entities;
using DAL.UnitOfWork;



namespace UI
{
    public class OrderView
    {
        private OrderService _orderService;
        private IOrderDetailService orderDetailService;
        private IProductService productService;
        private ITableService tableService;
        public OrderView(IUnitOfWork unitOfWork, ITableService tableService, IProductService productService, IOrderDetailService orderDetailService)
        {
            this._orderService = new OrderService(unitOfWork);
            this.orderDetailService = orderDetailService;
            this.productService = productService;
            this.tableService = tableService;
        }

        public void Menu()
        {
            int choose;
            do
            {
                Console.WriteLine("+--------------------+");
                Console.WriteLine("|1. Attach Order     |");
                Console.WriteLine("|--------------------|");
                Console.WriteLine("|2. History Bill     |");
                Console.WriteLine("|--------------------|");
                Console.WriteLine("|3. View Order Detail|");
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

        // add a new order
        public async void AttchOrder(int emp_no)
        {

            Console.Write("Enter product name: ");
            string pro_name = Console.ReadLine();
            if (string.IsNullOrEmpty(pro_name))
            {
                var listProByName = await this.productService.GetListProductByName(pro_name);
                Console.WriteLine("+--------------------------------------------+");
                Console.WriteLine("|ID     |Name                     |Price     ");
                Console.WriteLine("|--------------------------------------------|");
                foreach (var pro in listProByName)
                {
                    Console.WriteLine($"|{pro.Prod_no,-7}|{pro.Prod_name,-25}|{pro.Prod_price,-10}|");
                    Console.WriteLine("|--------------------------------------------|");
                }
                Console.WriteLine("+--------------------------------------------+");
                Console.WriteLine("==================================================================");
                Console.Write("Enter product_no: ");
                int pro_no = Convert.ToInt32(Console.ReadLine());
                var product = await this.productService.Find(pro_no);
                if (product != null)
                {
                    Order order = new Order();
                    order.CheckIn = DateTime.Now;
                    order.Emp_no = emp_no;
                    order.Table_no = 1;
                    OrderDetail detail = new OrderDetail();
                    detail.Product = product;
                    detail.Amount = Convert.ToInt32(Console.ReadLine());
                    detail.Order = order;
                    await this._orderService.AttachOrder(order);
                    this.orderDetailService.Attach(detail);
                }
            }

        }
        public async void HistoryBill()
        {
            DateTime since = DateTime.Now;
            DateTime toDate = DateTime.Now;

            var list = await this._orderService.GetHistoryBill(since, toDate);
            Console.WriteLine("+------------------------------------------------------+");
            Console.WriteLine("|ID          |CheckIn     |CheckOut    |ToTalPrice     |");
            Console.WriteLine("|------------------------------------------------------|");
            list.ToList().ForEach(order =>
            {
                Console.WriteLine($"|{order.Order_no,-10}|{order.CheckIn,-12}|{order.CheckOut,-12}|{order.TotalPrice,-15}");
            });
            Console.WriteLine("+------------------------------------------------------+");
            Console.Write("Enter ID order but orderdetail: ");
            int order_no = Convert.ToInt32(Console.ReadLine());
            ViewOrderDetail(order_no);

        }

        public async void ViewOrderDetail(int order_no)
        {
            var result = await this._orderService.Find(order_no);
            if (result != null)
            {
                Console.WriteLine("ID: " + result.Order_no);
                Console.WriteLine("Name Product                   |Amount|");
                result.Details.ToList().ForEach(detail =>
                {
                    Console.WriteLine($"{detail.Product.Prod_name,-30}|{detail.Amount}");
                });
                Console.WriteLine(result.TotalPrice);
                Console.WriteLine(result.Discount);
            }
            Console.WriteLine("id is not valid");
        }

    }
}