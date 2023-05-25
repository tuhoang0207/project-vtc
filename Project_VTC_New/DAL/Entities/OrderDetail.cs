using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    [Table("OrderDetail")]
    public class OrderDetail
    {
        [Key]
        public int Prod_no { get; set; }
        [Key]
        public int Order_no { get; set; }
        public Decimal TotalPrice { get; set; }
        public int Amount { get; set; }

        [ForeignKey(nameof(Prod_no))]
        public virtual Product Product { get; set; }
        [ForeignKey(nameof(Order_no))]
        public virtual Order Order { get; set; }
    }
}
