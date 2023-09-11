using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryDAL.Models
{
    public class Student
    {
        [Key]
        public int StudentId { get; set; }

        public string Name { get; set; }

 
        public int Semester { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public virtual ICollection<IssuedBook> IssuedBooks { get; set; }
    }
}
