using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BlogProject_MaryLouiseAnhanceAbrena.Models;
using System.Diagnostics;

namespace BlogProject_MaryLouiseAnhanceAbrena.Controllers
{
    public class TeacherController : Controller
    {
        // GET: Teacher
        public ActionResult Index()
        {
            return View();
        }
        //this is to link the list page to this page
        // GET: /Teacher/List
        /// <summary>
        /// Shows all the Teacher in the database
        /// </summary>
        /// <example>
        /// /Teacher/List
        /// </example>
        /// <returns>
        /// The list of teachers in the database
        /// </returns>
        public ActionResult List(string SearchKey = null)
        {
            TeacherDataController controller = new TeacherDataController();
            IEnumerable<Teacher> Teacher = controller.InfoTeachers(SearchKey);
            return View(Teacher);
        }

        //GET: /Teacher/Show/{id} 
        /// <summary>
        /// Show a specific teacher in the database
        /// </summary>
        /// <example>Teacher/Show/7
        /// </example>
        /// <returns>
        /// Shanon Barton
        /// </returns>
        public ActionResult Show(int id)
        {
            TeacherDataController controller = new TeacherDataController();
            Teacher newTeacher = controller.FindTeacher(id);


            return View(newTeacher);
        }
        // Delete the teachers with confirm
        public ActionResult DeleteConfirm(int id)
        {
            TeacherDataController controller = new TeacherDataController();
            Teacher newTeacher = controller.FindTeacher(id);


            return View(newTeacher);
        }
        //POST: /Teacher/Delete/{id}
        [HttpPost]
        public ActionResult Delete(int id)
        {
            TeacherDataController controller = new TeacherDataController();
            controller.DeleteTeacher(id);
            return RedirectToAction("List");
        }

        //GET: /Teacher/New
        public ActionResult New()
        {
            return View();
        }
        //POST : /Teacher/Create
        [HttpPost]
        public ActionResult Create(int TeacherId, string TeacherFname, string TeacherLname, string EmployeeNumber, DateTime HireDate, decimal Salary)
        {

            //Identify that this method is running
            Debug.WriteLine("I have accessed the Create Method");

            Teacher NewTeacher = new Teacher();
            NewTeacher.TeacherId = TeacherId;
            NewTeacher.TeacherFname = TeacherFname;
            NewTeacher.TeacherLname = TeacherLname;
            NewTeacher.EmployeeNumber = EmployeeNumber;
            NewTeacher.HireDate = HireDate;
            NewTeacher.Salary = Salary;

            TeacherDataController controller = new TeacherDataController();
            controller.AddTeacher(NewTeacher);

            return RedirectToAction("List");
        }
    }
}