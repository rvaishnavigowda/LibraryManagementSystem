using LibraryDAL.repo;
using LibraryDAL.unitofwork;
using System;


namespace LibraryManagementSystem.Logic
{
   
    public class LLoginValidation 
    
        {
        private readonly UnitOfWork _unitOfWork;

        public LLoginValidation()
        {
            _unitOfWork = new UnitOfWork();
        }

        public int LibrarianLogin(string lUserName, string lPassword)
            {
                var librarian = _unitOfWork.LibrarianRepository.GetLibrarianByUsername(lUserName, lPassword);

                if (librarian != null && librarian.librarianUserName == lUserName && librarian.librarianPassword == lPassword)
                {
                    return 1;
                }
                else if (librarian != null)
                {
                    return -1;
                }
                else
                {
                    return 0;
                }
            }
        }
    }
