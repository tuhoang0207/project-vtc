using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    [Table("Category")]
    public class Category
    {
        [Key]
        public int Cate_no { get; set; }
        [StringLength(100)]
        public string Cate_name { get; set; }
        [StringLength(200)]
        public string Cate_Description { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
