using LibraryDAL.Models;
using LibraryDAL.repo;
using LibraryDAL.unitofwork;
using System;

namespace LibraryManagementSystem.Logic
{
    public class AddStudent
    {
        private readonly UnitOfWork _unitOfWork;

        public AddStudent()
        {
            _unitOfWork = new UnitOfWork();
        }

        public int AddS(string studentName, int semester, string username, string password)
        {
            var studentRepository = _unitOfWork.StudentRepository;

            if (studentRepository.StudentExists(username))
            {
                return -1;
            }

            var student = new Student
            {
                Name = studentName,
                Semester = semester,
                Username = username,
                Password = password
            };

            studentRepository.AddStudent(student);

            _unitOfWork.Save();

            return 1;
        }
    }
}
