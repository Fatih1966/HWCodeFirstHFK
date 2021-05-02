using System;
using System.Collections.Generic;
using System.Text;

namespace HWCodeFirstHFK.Entity
{
    public class Person
    {
        public int PersonID { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public Nullable<System.DateTime> HireDate { get; set; }
        public Nullable<System.DateTime> EnrollmentDate { get; set; }
        public string Discriminator { get; set; }

        //public List<Course> courses { get; set; }

        public ICollection<CourseInstructor> CourseInstructors { get; set; }

        public OfficeAssignment officeAssignment { get; set; }
    }
}
