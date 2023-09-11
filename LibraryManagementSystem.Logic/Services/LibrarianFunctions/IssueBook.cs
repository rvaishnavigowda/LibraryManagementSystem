using LibraryDAL.unitofwork;
using LibraryDAL.Models;
using System;
using LibraryDAL.repo.StudentRepository;
using LibraryDAL.repo.BookRepository;

namespace LibraryManagementSystem.Logic
{
    public class IssueBook
    {
        private readonly UnitOfWork _unitOfWork;

        public IssueBook()
        {
            _unitOfWork = new UnitOfWork();
        }

        public int issueBook(string studentUserName, string bookName, DateTime issueDate)
        {
            DateTime dateTime = issueDate;
            string issuedDate = dateTime.ToString("yyyy-MM-dd");
            BookRepository Bdb = (BookRepository)_unitOfWork.BookRepository;
            StudentRepository Sdb = (StudentRepository)_unitOfWork.StudentRepository;

            int studentID = Sdb.GetStudentId(studentUserName);

            if (!_unitOfWork.IssueBookRepository.StudentExists(studentUserName))
            {
                return -1; 
            }

            if (!_unitOfWork.IssueBookRepository.BookExists(bookName))
            {
                return -2;
            }

            if (!_unitOfWork.IssueBookRepository.IsBookInStock(bookName))
            {
                return -3;
            }

            if (!_unitOfWork.IssueBookRepository.IsStudentAllowedToIssueBook(studentID))
            {
                return -4; 
            }

            var issuedBook = new IssuedBook
            {
                StudentId = studentID,
                BookId = Bdb.GetBookIdByName(bookName),
                IssueDate = issuedDate,
                IsIssued = true
            };

            _unitOfWork.IssueBookRepository.IssueBook(issuedBook);
            _unitOfWork.IssueBookRepository.DecreaseStock(bookName);
            _unitOfWork.Save();

            return 1;
        }
    }
}
