using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryDAL.Models
{
    public class Librarian
    {
        public string librarianName { get; set; }
        [Key]
        public string librarianUserName { get; set; }

        public string librarianPassword { get; set; }
    }
}
