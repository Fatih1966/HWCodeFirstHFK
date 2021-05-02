using System;
using System.Collections.Generic;
using System.Text;

namespace HWCodeFirstHFK.Entity
{
    public class Course
    {
        public int CourseID { get; set; }
        public string Title { get; set; }
        public int Credits { get; set; }
        public int DepartmentID { get; set; }

        public virtual Department Department { get; set; }
        public virtual OnlineCourse OnlineCourse { get; set; }
        public virtual OnSiteCourse OnsiteCourse { get; set; }

        public virtual List<StudentGrade> StudentGrades { get; set; }

        //public virtual List<Person> People { get; set; }
        public ICollection<CourseInstructor> CourseInstructors { get; set; }
    }
}
