using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryDAL.Models
{
    public class IssuedBook
    {
        [Key]
        public int IssuedBookId { get; set; }

        public int BookId { get; set; }

        public bool IsIssued { get; set; }

        public string IssueDate { get; set; }
        public string ReturnDate { get; set; }

        public int StudentId { get; set; }
        public virtual Student Student { get; set; }
    }
}
