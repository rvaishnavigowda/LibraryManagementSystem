using LibraryDAL.Context;
using LibraryDAL.repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryDAL.repo.PublicationRepsoitory;
using LibraryDAL.repo.StudentRepository;
using LibraryDAL.repo.LibrarianRepository;
using LibraryDAL.repo.IssueBookRepository;
using LibraryDAL.repo.BookRepository;

namespace LibraryDAL.unitofwork
{
   
        public class UnitOfWork :  IUnitOfWork, IDisposable
    {
        internal readonly LibraryContext _context;

        public UnitOfWork()
        {
            _context = new LibraryContext();

        }

        private PublicationRepository _publicationRepository;
            public PublicationRepository PublicationRepository
            {
                get
                {
                    if (_publicationRepository == null)
                    {
                        _publicationRepository = new PublicationRepository(_context);
                    }
                    return _publicationRepository;
                }
            }

            private BookRepository _bookRepository;
            public BookRepository BookRepository
            {
                get
                {
                    if (_bookRepository == null)
                    {
                        _bookRepository = new BookRepository(_context);
                    }
                    return _bookRepository;
                }
            }

            private BranchRepository _branchRepository;
            public BranchRepository BranchRepository
            {
                get
                {
                    if (_branchRepository == null)
                    {
                        _branchRepository = new BranchRepository(_context);
                    }
                    return _branchRepository;
                }
            }

            private IssueBookRepository _issueBookRepository;
            public IssueBookRepository IssueBookRepository
            {
                get
                {
                    if (_issueBookRepository == null)
                    {
                        _issueBookRepository = new IssueBookRepository(_context);
                    }
                    return _issueBookRepository;
                }
            }

            private LibrarianRepository _librarianRepository;
            public LibrarianRepository LibrarianRepository
            {
                get
                {
                    if (_librarianRepository == null)
                    {
                        _librarianRepository = new LibrarianRepository(_context);
                    }
                    return _librarianRepository;
                }
            }

            private StudentRepository _studentRepository;
            public StudentRepository StudentRepository
            {
                get
                {
                    if (_studentRepository == null)
                    {
                        _studentRepository = new StudentRepository(_context);
                    }
                    return _studentRepository;
                }
            }

      

        public void Save()
            {
                _context.SaveChanges();
            }

            public void Dispose()
            {
                _context.Dispose();
            }

        void IUnitOfWork.Save()
        {
            throw new NotImplementedException();
        }

        void IUnitOfWork.Dispose()
        {
            throw new NotImplementedException();
        }
    }
    }
