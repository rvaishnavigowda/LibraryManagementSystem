using LibraryDAL.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryDAL.Context
{
    public class LibraryContext:DbContext
    {
        public LibraryContext(): base("LibraryContext")
        {
        }

        public DbSet<Branch> Branches { get; set; }

        public DbSet<Publication> Publications { get; set; }

        public DbSet<Book> Books { get; set; }

        public DbSet<Student> Students { get; set; }
        public DbSet<Librarian> Librarians { get; set; }

        public DbSet<IssuedBook> IssuedBooks { get; set; }
    }
}

