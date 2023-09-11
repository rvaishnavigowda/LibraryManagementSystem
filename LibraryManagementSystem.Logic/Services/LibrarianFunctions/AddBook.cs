using LibraryDAL.repo;
using LibraryDAL.unitofwork;
using System;
using System.Linq;
using LibraryDAL.Models;

namespace LibraryManagementSystem.Logic
{
    public class AddBook
    {
        private readonly UnitOfWork _unitOfWork;

        public AddBook()
        {
            _unitOfWork = new UnitOfWork();
        }

        public int AddB(string bookName, string publicationName, string branchName, int stock)
        {
            try
            {
                var bookRepository = _unitOfWork.BookRepository;

                if (bookRepository.BookExists(bookName, publicationName, branchName))
                {
                    Book existingBook = bookRepository.GetBookByName(bookName, publicationName, branchName);
                    bookRepository.UpdateBookStock(existingBook, stock);
                    _unitOfWork.Save();
                    return 1;
                }

                var publicationRepository = _unitOfWork.PublicationRepository;
                bool publicationExists = publicationRepository.PublicationExists(publicationName);

                var branchRepository = _unitOfWork.BranchRepository;
                bool branchExists = branchRepository.BranchExists(branchName);

                if (!publicationExists)
                {
                    return -1;
                }

                if (!branchExists)
                {
                    return -2;
                }

                var newBook = new Book
                {
                    BookName = bookName.ToLower(),
                    PublicationId = publicationRepository.GetPublicationIdByName(publicationName),
                    BranchId = branchRepository.GetBranchIdByName(branchName),
                    stock = stock
                };

                bookRepository.AddNewBook(newBook);
                _unitOfWork.Save();
                return 2;
            }
            catch (Exception)
            {
                return -3;
            }
            finally
            {
                _unitOfWork.Dispose();
            }
        }
    }
}
