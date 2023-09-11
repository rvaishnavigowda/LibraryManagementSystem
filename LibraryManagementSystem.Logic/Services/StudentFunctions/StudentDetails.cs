using LibraryDAL.Models;
using LibraryDAL.unitofwork;
using System;

namespace LibraryDAL.Services
{
    public class StudentDetails
    {
        private readonly UnitOfWork _unitOfWork;

        public StudentDetails()
        {
            _unitOfWork = new UnitOfWork();
        }

        public Student GetDetails(string username)
        {
            return _unitOfWork.StudentRepository.GetStudentByUsername(username);
        }

        public int GetStudentIdByUsername(string username)
        {
            return _unitOfWork.StudentRepository.GetStudentId(username);
        }
    }
}
