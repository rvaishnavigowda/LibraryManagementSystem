//using LibraryDAL.Models;
//using LibraryDAL.Services;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using System.Web.Mvc;
//using LibraryDAL.Context;
//using LibraryDAL.repo;
//using LibraryDAL.repo.StudentRepository;

//namespace LibraryManagementSystem.Controllers
//{
//    public class StudentController : Controller
//    {
//        // GET: Student
//        public ActionResult StudentLogin()
//        {
//            return View();
//        }

//        [HttpPost]
//        public ActionResult StudentLogin(string sUserName, string sPassword)
//        {
//            SLoginValidation sLoginValidation = new SLoginValidation();
//            SLoginValidation.StudentLoginResult loginResult = sLoginValidation.StudentLogin(sUserName, sPassword);

//            if (loginResult.ResultCode == 1)
//            {
//                Session["StudentUsername"] = loginResult.StudentUsername;
//                return RedirectToAction("StudentFunction");
//            }
//            else if (loginResult.ResultCode == -1)
//            {
//                ViewBag.ErrorMessage = "Incorrect password.";
//            }
//            else if (loginResult.ResultCode == -2)
//            {
//                ViewBag.ErrorMessage = "Student not found.";
//            }
//            else
//            {
//                ViewBag.ErrorMessage = "An error occurred.";
//            }

//            return View();
//        }

//        public ActionResult StudentFunction()
//        {
//            return View();
//        }

//        public ActionResult StudentAccount()
//        {
//            string studentusername = (string)Session["StudentUsername"];
//            Student student = null;

//            StudentDetails studentDetails = new StudentDetails();


//            Student studentDetail=new Student();
//          //  student = studentDetails.Getdetails(studentusername);

//            //student = studentDetail;

//            if (student != null)
//            {
//                return View(student);
//            }
//            else
//            {
//                ViewBag.ErrorMessage = "Student information not available.";
//                return View();
//            }
//        }

//        public ActionResult StudentBookReport()
//        {
//            string studentUsername = (string)Session["StudentUsername"];
//            StudentRepository db = new StudentRepository();
//            int studentId = db.GetStudentId(studentUsername);

//            if (studentId != -1) 
//            {
//                using (var context = new LibraryContext())
//                {
//                    List<IssuedBook> issuedBooks = context.IssuedBooks
//                        .Where(ib => ib.StudentId == studentId )
//                        .ToList();

                 

//                    ViewBag.IssuedBooks = issuedBooks;
//                    return View(issuedBooks);
//                }
//            }
//            else
//            {
//                ViewBag.ErrorMessage = "Student not found.";
//                return View();
//            }
//        }




//    }
//}
