using LibraryDAL.Context;
using LibraryDAL.Models;
using LibraryDAL.unitofwork;
using System;
using System.Linq;

namespace LibraryDAL.repo.IssueBookRepository
{
    public class IssueBookRepository
    {
        private readonly LibraryContext _context;

        public IssueBookRepository(LibraryContext context)
        {
            _context = context;
        }
        public bool StudentExists(string studentUserName)
        {
            return _context.Students.Any(s => s.Username == studentUserName);
        }

        public bool BookExists(string bookName)
        {
            return _context.Books.Any(b => b.BookName.ToLower() == bookName.ToLower());
        }

        public bool IsBookInStock(string bookName)
        {
            var book = _context.Books.FirstOrDefault(b => b.BookName.ToLower() == bookName.ToLower());
            return book != null && book.stock > 0;
        }

        public bool IsStudentAllowedToIssueBook(int studentID)
        {
            var hasIssuedBook = _context.IssuedBooks.Any(ib => ib.StudentId == studentID && ib.IsIssued);

            return !hasIssuedBook;
        }

        public void IssueBook(IssuedBook issuedBook)
        {
            _context.IssuedBooks.Add(issuedBook);
        }

        public IssuedBook GetIssuedBook(int studentID, int bookId)
        {
            return _context.IssuedBooks.FirstOrDefault(ib => ib.StudentId == studentID && ib.BookId == bookId && ib.IsIssued);
        }

        public void DecreaseStock(string bookName)
        {
            var book = _context.Books.FirstOrDefault(b => b.BookName.ToLower() == bookName.ToLower());
            if (book != null)
            {
                book.stock--;
            }
        }
    }
}
