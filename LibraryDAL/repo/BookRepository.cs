using LibraryDAL.Context;
using LibraryDAL.Models;
using System;
using System.Linq;

namespace LibraryDAL.repo.BookRepository

{
    public class BookRepository
    {
        private readonly LibraryContext _context;

        public BookRepository(LibraryContext context)
        {
            _context = context;
        }

        public void AddNewBook(Book book)
        {
            _context.Books.Add(book);
        }

        public bool BookExists(string bookName, string publicationName, string branchName)
        {
            return _context.Books.Any(b =>
                b.BookName.ToLower() == bookName.ToLower() &&
                b.Publication.PublicationName.ToLower() == publicationName.ToLower() &&
                b.Branch.BranchName.ToLower() == branchName.ToLower()
            );
        }

        public Book GetBookByName(string bookName, string publicationName, string branchName)
        {
            return _context.Books
                .Include("Publication")
                .Include("Branch")
                .FirstOrDefault(b =>
                    b.BookName.ToLower() == bookName.ToLower() &&
                    b.Publication.PublicationName.ToLower() == publicationName.ToLower() &&
                    b.Branch.BranchName.ToLower() == branchName.ToLower()
                );
        }

        public Book GetBookBytheId(int bookId)
        {
            return _context.Books.FirstOrDefault(b => b.BookId == bookId);
        }

        public int GetBookIdByName(string bookName)
        {
            var book = (from b in _context.Books
                        where b.BookName.ToLower() == bookName.ToLower()
                        select b).FirstOrDefault();

            if (book != null)
            {
                return book.BookId;
            }
            else
            {
                return -1;
            }
        }

        public void UpdateBookStock(Book book, int stock)
        {
            book.stock += stock;
        }
    }
}
