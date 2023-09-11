using LibraryDAL.Context;
using LibraryDAL.Models;
using LibraryDAL.unitofwork;
using System;
using System.Linq;

namespace LibraryManagementSystem.Logic
{
    public class ReturnBook
    {
        private readonly UnitOfWork _unitOfWork;

        public ReturnBook()
        {
            _unitOfWork = new UnitOfWork();
        }

        public void returnBook(int studentID, int bookId, DateTime returnDate)
        {
            DateTime dateTime = returnDate;
            string rdate = dateTime.ToString("yyyy-MM-dd");
            
                    var issuedBookRepository = _unitOfWork.IssueBookRepository;
                    var bookRepository = _unitOfWork.BookRepository;

                    var issuedBook = issuedBookRepository.GetIssuedBook(studentID, bookId);

                    if (issuedBook != null)
                    {
                        issuedBook.ReturnDate = rdate;
                        issuedBook.IsIssued = false;

                        var book = bookRepository.GetBookBytheId(bookId);

                if (book != null)
                {
                    bookRepository.UpdateBookStock(book, 1);
                    _unitOfWork.Save();
                }
                

                   
                       
                    }
                    else
                    {
                        throw new InvalidOperationException("Book not found or not issued to this student.");
                   }
                }
                

        public void Dispose()
        {
            _unitOfWork.Dispose();
        }
    }
}
