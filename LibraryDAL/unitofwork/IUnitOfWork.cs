using LibraryDAL.repo;
using LibraryDAL.repo.PublicationRepsoitory;
using LibraryDAL.repo.StudentRepository;
using LibraryDAL.repo.LibrarianRepository;
using LibraryDAL.repo.IssueBookRepository;
using LibraryDAL.repo.BookRepository;


namespace LibraryDAL.unitofwork
{
    public interface IUnitOfWork
    {
        PublicationRepository PublicationRepository { get; }
        BookRepository BookRepository { get; }
        BranchRepository BranchRepository { get; }
        IssueBookRepository IssueBookRepository { get; }
        LibrarianRepository LibrarianRepository { get; }
        StudentRepository StudentRepository { get; }

        void Save();
        void Dispose();
    }
}
