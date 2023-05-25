using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    [Table("TableSeat")]
    public class Table
    {
        [Key]
        public int Table_no { get; set; }
        public string Table_name { get; set; }
        public int Table_st { get; set; }
        [StringLength(50)]
        public string Table_Description { get; set; }
    }
}
