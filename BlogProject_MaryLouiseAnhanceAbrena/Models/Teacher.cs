using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;

namespace BlogProject_MaryLouiseAnhanceAbrena.Models
{
    public class Teacher
    {
        /// The following propert define the teachers in our database
        public int TeacherId;
        public string TeacherFname;
        public string TeacherLname;
        public string EmployeeNumber;
        public DateTime HireDate;
        public decimal Salary;
    }
}