using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    [Table("Employee")]
    public class Employee
    {
        [Key]
        public int Emp_no { get; set; }
        [StringLength(20)]
        public string Last_name { get; set; }
        [StringLength(30)]
        public string First_name { get; set; }
        [StringLength(11)]
        public string PhoneNumber { get; set; }

        [ForeignKey(nameof(Emp_no))]
        public AccountEmployee AccountEmployee { get; set; }
        public virtual ICollection<Salary> Salaries { get; set; }
    }
}
