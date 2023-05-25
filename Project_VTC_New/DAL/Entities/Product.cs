using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    [Table("Product")]
    public class Product
    {
        [Key]
        public int Prod_no { get; set; }
        [StringLength(100)]
        public string Prod_name { get; set; }
        public decimal Prod_price { get; set; }
        public int Prod_st { get; set; }
        public int Cate_no { get; set; }

        [ForeignKey(nameof(Cate_no))]
        public Category Category { get; set; }
    }
}
