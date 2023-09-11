using LibraryDAL.Context;
using LibraryDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace LibraryDAL.Services
{
    public class StudentBookReport
    {
        private readonly LibraryContext _context;

        public StudentBookReport()
        {
            _context = new LibraryContext();
        }

       

        public List<Book> GetBooksIssuedToStudent(int studentId)
        {
            var issuedBooks = _context.IssuedBooks
                .Where(ib => ib.StudentId == studentId && ib.IsIssued)
                .Join(_context.Books, ib => ib.BookId, b => b.BookId, (ib, b) => b)
                .ToList();

            return issuedBooks;
        }


        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
