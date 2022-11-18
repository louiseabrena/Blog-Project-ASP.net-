using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BlogProject_MaryLouiseAnhanceAbrena.Models;

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
    }
}