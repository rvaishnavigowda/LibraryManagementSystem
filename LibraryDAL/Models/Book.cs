using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryDAL.Models
{
    public class Book
    {
        [Key]
        public int BookId { get; set; }
       
        public string BookName { get; set; }
        
        public int PublicationId { get; set; }
        public virtual Publication Publication { get; set; }

        public int BranchId { get; set; }
        public virtual Branch Branch { get; set; }

        public int stock { get; set; }


        public virtual ICollection<IssuedBook> IssuedBooks { get; set; }
    }
}
