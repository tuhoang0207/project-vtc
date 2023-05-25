using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    [Table("AccountAdmin")]
    public class AccountAdmin
    {
        [Key]
        public int Admin_no { get; set; }
        [StringLength(50)]
        [Required]
        public string UserName { get; set; } = null!;
        [StringLength(200)]
        [Required]
        public string PassWord { get; set; } = null!;
        public int Role { get; set; }




    }
}
