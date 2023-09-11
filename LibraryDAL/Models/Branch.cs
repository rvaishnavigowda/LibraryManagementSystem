using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryDAL.Models
{
    public class Branch
    {
        [Key]
        public int BranchId { get; set; }

        [StringLength(450)]
        [Index(IsUnique = true)]

        public string BranchName { get; set; }
    }
}
