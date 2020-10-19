using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CrudApi.Models
{
    public class Student
    {
      
        public int StudentID { get; set; }
        public string StudentName { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email{ get; set; }
    }
}
