using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;    

namespace EmplDBA.API.Models
{
    public class Employee
    {
        [Key]
        public long EmployeeID { get; set; }
        [StringLength(50)]
        [Display(Name = "Имя")]
        public string Name { get; set; }
        [StringLength(50)]
        [Display(Name = "Фамилия")]
        public string Surname { get; set; }
        [Display(Name = "Возраст")]

        public short Age { get; set; }
        public long PostID { get; set; } 
    }
}
