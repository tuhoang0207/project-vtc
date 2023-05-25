using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    [Table("Order")]
    public class Order
    {
        [Key]
        public int Order_no { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime? CheckOut { get; set; }
        public int Emp_no { get; set; }
        public int Table_no { get; set; }
        public int? Cus_no { get; set; }
        public int? Payment { get; set; }
        public Decimal? TotalPrice { get; set; }
        public int? Discount { get; set; }
        public  int Order_st { get; set; }
        public virtual ICollection<OrderDetail> Details { get; set; }

    }
}
