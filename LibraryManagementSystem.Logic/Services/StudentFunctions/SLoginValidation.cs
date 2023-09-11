using LibraryDAL.repo;
using LibraryDAL.unitofwork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryDAL.Services
{
    public class SLoginValidation
    {
        private readonly UnitOfWork _unitOfWork;

        public SLoginValidation()
        {
            _unitOfWork = new UnitOfWork();
        }

        public class StudentLoginResult
        {
            public int ResultCode { get; set; }
            public string StudentUsername { get; set; }
        }

        public StudentLoginResult StudentLogin(string sUserName, string sPassword)
        {
            var student = _unitOfWork.StudentRepository.GetStudentByUsername(sUserName, sPassword);

            if (student != null)
            {
                var result = new StudentLoginResult
                {
                    ResultCode = 1,
                    StudentUsername = student.Username
                };
                return result;
            }
            else
            {
                var result = new StudentLoginResult { ResultCode = -1 };
                return result;
            }
        }
    }
}
