using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibraryDAL.Models;
using LibraryManagementSystem.Logic;



namespace LibraryManagementSystem.Controllers
{
    public class LibrarianController : Controller
    {
        // GET: Librarian
        public ActionResult LibrarianLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult LibrarianLogin(string lUserName, string lPassword)
        {
            LLoginValidation lLoginValidation = new LLoginValidation();
            int loginResult = lLoginValidation.LibrarianLogin(lUserName, lPassword);

            if (loginResult == 1)
            {
                return RedirectToAction("LibrarianFunction");
            }
            else if (loginResult == -1)
            {
                ViewBag.ErrorMessage = "Invalid username or password.";
                return View();
            }
            else
            {
                ViewBag.ErrorMessage = "Username not found.";
                return View();
            }

        }

        public ActionResult LibrarianFunction()
        {
            return View();
        }

        public ActionResult addPublication()
        {
            return View();
        }

        [HttpPost]
        public ActionResult addPublication(string publicationName)
        {
            AddPublication addPublication = new AddPublication();
            int res = addPublication.AddP(publicationName.ToLower());
            if (res == 1)
            {
                ViewBag.successMessage = "Publication added successfully";
                return View();
                //return RedirectToAction("LibrarianFunction", "Librarian");
            }
            else
            {
                ViewBag.ErrorMessage = "Publication already exists";
                return View();
            }

        }

        public ActionResult addBranch()
        {
            return View();
        }

        [HttpPost]
        public ActionResult addBranch(string branchName)
        {
           AddBranch addBranch=new AddBranch();
            int res = addBranch.AddB(branchName.ToLower());
            if (res == 1)
            {
                ViewBag.successMessage = "Branch added successfully";
                return View();
                //return RedirectToAction("LibrarianFunction", "Librarian");
            }
            else
            {
                ViewBag.ErrorMessage = "Branch already exists";
                return View();
            }
        }

        public ActionResult addBook()
        {
            return View();
        }

        [HttpPost]
        public ActionResult addBook(string bookName, string publicationName, string branchName, int stock)
        {
            AddBook addBook = new AddBook();
            int res = addBook.AddB(bookName.ToLower(), publicationName.ToLower(), branchName.ToLower(), stock);
            if (res == 2)
            {
                ViewBag.successMessage = "Book added successfully";
                return View();
                //return RedirectToAction("LibrarianFunction", "Librarian");
            }
            else if (res == 1)
            {
                ViewBag.stockMessage = "book exits, stock has been added.";
                return View();
            }
            else if (res == -2)
            {
                ViewBag.ErrorMessage = "Branch doesn't exist";
                return View();
            }

            else if (res == 1)
            {
                ViewBag.ErrorMessage = "Publication doesn't exists";
                return View();
            }
            else
            {
                ViewBag.ErrorMessage = "Publication and branch doesn't exists";
                return View();
            }
        }

        public ActionResult addStudent()
        {
            return View();
        }

        [HttpPost]
        public ActionResult addStudent(string studentName, int semester, string username, string password)
        {
            AddStudent addStudent = new AddStudent();
            int res = addStudent.AddS(studentName.ToLower(), semester, username, password);
            if (res == 1)
            {
                ViewBag.successMessage = "Student added successfully";
                return View();
                //return RedirectToAction("LibrarianFunction", "Librarian");
            }
            else
            {
                ViewBag.ErrorMessage = "Student already exists";
                return View();
            }
        }

        public ActionResult issueBook()
        {
            return View();
        }

        [HttpPost]
        public ActionResult issueBook(string studentUserName, string bookName, DateTime issueDate)
        {
            IssueBook issueBook=new IssueBook();
            int res = issueBook.issueBook(studentUserName, bookName.ToLower(), issueDate);

            if (res == 1)
            {
                ViewBag.successMessage = "Issued book successfully";
                return View();
                //return RedirectToAction("LibrarianFunction", "Librarian");

            }
            else if (res == -1)
            {
                ViewBag.ErrorMessage = "Student doesn't exist";
                return View();
            }
            else if (res == -2)
            {
                ViewBag.ErrorMessage = "Book not in the record";
                return View();
            }
            else if (res == -3)
            {
                ViewBag.ErrorMessage = "Book out of stock";
                return View();
            }
            else if (res == -4)
            {
                ViewBag.ErrorMessage = "student can be issued with only one book at a time.";
                return View();
            }
            else

            {
                ViewBag.ErrorMessage = "An error occurred";
                return View();
            }

        }

        public ActionResult returnBook()
        {
            return View();
        }

        [HttpPost]
        public ActionResult returnBook(int bookid, int studentID, DateTime returnDate)
        {
            ReturnBook returnBook = new ReturnBook();
            try
            {
                returnBook.returnBook(studentID, bookid, returnDate);
                ViewBag.successMessage = "Returned book successfully.";
                return View();
                //return RedirectToAction("LibrarianFunction", "Librarian");
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View();
            }
        }


    }
}

