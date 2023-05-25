using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    [Table("Customer")]
    public class Customer
    {
        [Key]
        public int Cus_no { get; set; }
        [StringLength(20)]
        public string Last_name { get; set; }
        [StringLength(30)]
        public string First_name { get; set;}
        [StringLength(11)]
        public string PhoneNumber { get; set; }
        public int Cus_st { get; set; }
    }
}
