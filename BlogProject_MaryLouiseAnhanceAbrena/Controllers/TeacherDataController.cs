using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography;
using System.Web.Http;
using System.Web.Mvc;
using BlogProject_MaryLouiseAnhanceAbrena.Models;
using Microsoft.Ajax.Utilities;
using MySql.Data.MySqlClient;
using HttpGetAttribute = System.Web.Http.HttpGetAttribute;
using RouteAttribute = System.Web.Http.RouteAttribute;

namespace BlogProject_MaryLouiseAnhanceAbrena.Controllers
{
    public class TeacherDataController : ApiController
    {
        private SchoolDbContext Blogteacher = new SchoolDbContext();
        /// <summary>
        /// Returns all the information of the teachers in our database / system
        /// </summary>
        /// <example>
        /// GET api/TeacherDataController/InfoTeachers
        /// </example>
        /// <returns>
        /// A list of the teachers (teacherid, fistname, lastname, employeeid, hiredate, salary) 
        /// </returns>
       
        [HttpGet]
        [Route("api/TeacherData/InfoTeachers/{SearchKey?}")]
        public IEnumerable<Teacher> InfoTeachers(string SearchKey=null)
        {
            MySqlConnection Conn = Blogteacher.AccessDatabase();
            Conn.Open();

            MySqlCommand cmd = Conn.CreateCommand();

            cmd.CommandText = "Select * from teachers where lower(teacherfname) like lower(@key) or lower(teacherlname) like lower('key') or lower(concat(teacherfname, ' ', teacherlname)) like lower(@key)";

            cmd.Parameters.AddWithValue("@key", "%" + SearchKey + "%");

            MySqlDataReader ResultSet = cmd.ExecuteReader();

            List<Teacher> Teacher = new List<Teacher> { };
            while (ResultSet.Read())
            {
                int TeacherId = (int)ResultSet["teacherid"];
                string TeacherFname = (string)ResultSet["teacherfname"];
                string TeacherLname = (string)ResultSet["teacherlname"];
                string EmployeeNumber =(string)ResultSet["employeenumber"];
                DateTime HireDate = (DateTime)ResultSet["hiredate"];
                decimal Salary = (decimal)ResultSet["salary"];
                
                Teacher newTeacher = new Teacher();
                newTeacher.TeacherId = TeacherId;
                newTeacher.TeacherFname = TeacherFname;
                newTeacher.TeacherLname = TeacherLname;
                newTeacher.EmployeeNumber = EmployeeNumber;
                newTeacher.HireDate = HireDate;
                newTeacher.Salary = Salary;

                Teacher.Add(newTeacher);
            }
            Conn.Close();

            return Teacher;
        }
        [HttpGet]
        public Teacher FindTeacher(int id)
        {
            Teacher newTeacher = new Teacher();

            MySqlConnection Conn = Blogteacher.AccessDatabase();
            Conn.Open();

            MySqlCommand cmd = Conn.CreateCommand();

            cmd.CommandText = "Select * from teachers where teacherid = " +id;

            MySqlDataReader ResultSet = cmd.ExecuteReader();

            while (ResultSet.Read())
            {
                int TeacherId = (int)ResultSet["teacherid"];
                string TeacherFname = (string)ResultSet["teacherfname"];
                string TeacherLname = (string)ResultSet["teacherlname"];
                string EmployeeNumber = (string)ResultSet["employeenumber"];
                DateTime HireDate = (DateTime)ResultSet["hiredate"];
                decimal Salary = (decimal)ResultSet["salary"];

                newTeacher.TeacherId = TeacherId;
                newTeacher.TeacherFname = TeacherFname;
                newTeacher.TeacherLname = TeacherLname;
                newTeacher.EmployeeNumber = EmployeeNumber;
                newTeacher.HireDate = HireDate;
                newTeacher.Salary = Salary;
            }
            return newTeacher;
        }
    }
}
