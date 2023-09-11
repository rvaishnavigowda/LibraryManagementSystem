using LibraryDAL.Context;
using LibraryDAL.Models;
using LibraryDAL.unitofwork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryDAL.repo.StudentRepository
{
    public class StudentRepository
    {
        private readonly LibraryContext _context;

        public StudentRepository(LibraryContext context)
        {
            _context = context;
        }

        public bool StudentExists(string username)
        {
            return _context.Students.Any(s => s.Username == username);
        }

        public int GetStudentId(string studentUserName)
        {
            var student = _context.Students.FirstOrDefault(s => s.Username == studentUserName);

            if (student != null)
            {
                return student.StudentId;
            }
            else
            {
                return -1;
            }
        }

        public Student GetStudentByUsername(string username, string password)
        {
            return _context.Students.FirstOrDefault(s => s.Username == username && s.Password == password);
        }

        public Student GetStudentByUsername(string username)
        {
            return _context.Students.FirstOrDefault(s => s.Username == username);
        }

        public void AddStudent(Student student)
        {
            _context.Students.Add(student);
            _context.SaveChanges();
        }
    }
}
