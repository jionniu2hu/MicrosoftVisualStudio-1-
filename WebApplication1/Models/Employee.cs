using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Employee
    {
        //主键
        [Key]
        public int EmployeeId { get; set; }
        public string Name{ get; set; }
        public int Salary{ get; set; }        
    }
}