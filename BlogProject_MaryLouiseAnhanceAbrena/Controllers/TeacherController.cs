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
            Teacher SelectedTeacher = controller.FindTeacher(id);


            return View(SelectedTeacher);
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
        //GET: /Teacher/Update/{id}
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Update(int id)
        {
            TeacherDataController controller = new TeacherDataController();
            Teacher SelectedTeacher = controller.FindTeacher(id);

            return View(SelectedTeacher);
        }

        //POST: /Author/Update/{id}
        /// <summary>
        /// Recieves a POST request which contains the informations about the Teacher in the list / system with new values.
        /// </summary>
        /// <param name="id">Teacher ID to update</param>
        /// <param name="TeacherFname">The updated first name of the teacher</param>
        /// <param name="TeacherLname">The updated last name of the teacher</param>
        /// <param name="EmployeeNumber">Updated employee number</param>
        /// <param name="HireDate">Updated hire date</param>
        /// <param name="Salary">The updated salary of the Teacher in the system</param>
        /// <returns>A webpage which provides the updated information of the Teachers</returns>
        /// <example>
        /// POST: /Teacher/Update/4
        /// FORM DATA:
        /// {
        /// Teacher Fist Name: Louise
        /// Teacher Last Name: Abrena
        /// Employee Number: TC5678
        /// HireDate: January 24, 2022
        /// Salary: $36.98
        /// }
        /// </example>
        [HttpPost]
        public ActionResult Update (int id, string TeacherFname, string TeacherLname, string EmployeeNumber, DateTime HireDate, decimal Salary)
        {
            Teacher TeacherInfo = new Teacher();
            TeacherInfo.TeacherFname = TeacherFname;
            TeacherInfo.TeacherLname = TeacherLname;
            TeacherInfo.EmployeeNumber = EmployeeNumber;
            TeacherInfo.HireDate = HireDate;
            TeacherInfo.Salary = Salary;

            TeacherDataController controller = new TeacherDataController();
            controller.UpdateTeacher(id, TeacherInfo);


            return RedirectToAction("Show/" + id);
        }

        /// <summary>
        /// Initiative: updating a teacher's data in the system with JSON
        /// </summary>
        /// <return>
        /// Teacher's information will be updated
        /// </return>
        /// <example>
        /// curl -H "Content-Type:application/json" -d @teacher.json "http://localhost:59734/api/Teacher/Update/10"
        /// FORM DATA: 
        ///  /// {
        /// Teacher Fist Name: John
        /// Teacher Last Name: Abrena
        /// Employee Number: T501
        /// HireDate: January 24, 2022 12:00:00 AM
        /// Salary: $86.10
        /// }
        /// </example>
    }
}