using LibraryDAL.Context;
using LibraryDAL.Models;
using LibraryDAL.unitofwork;
using System.Linq;

namespace LibraryDAL.repo.LibrarianRepository

{
    public class LibrarianRepository
    {
        private readonly LibraryContext _context;

        public LibrarianRepository(LibraryContext context)
        {
            _context = context;
        }

        public Librarian GetLibrarianByUsername(string username, string passsword)
        {
            return _context.Librarians.FirstOrDefault(l => l.librarianUserName == username);
        }
    }
}
