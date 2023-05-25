using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    [Table("AccountEmployee")]
    public class AccountEmployee
    {
        [Key]
        public int Emp_no { get; set; }
        [StringLength(50)]
        [Required]
        public string UserName { get; set; } = null!;
        [StringLength(200)]
        [Required]
        public string PassWord { get; set; } = null!;
        public int Role { get; set; }
        public int Emp_st { get; set; }
    }
}
