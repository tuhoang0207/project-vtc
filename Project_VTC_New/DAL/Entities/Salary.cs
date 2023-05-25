using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    [Table("Salary")]
    public class Salary
    {
        [Key]
        public int Emp_no { get; set; }
        public float Coefficients_salary { get; set; }
        public float WorkDay { get; set; }
        public float TotalSalary { get; set; }

        [ForeignKey(nameof(Emp_no))]
        public AccountEmployee accountEmployee { get; set; }
    }
}
