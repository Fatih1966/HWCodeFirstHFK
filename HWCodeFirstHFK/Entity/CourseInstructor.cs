using System;
using System.Collections.Generic;
using System.Text;

namespace HWCodeFirstHFK.Entity
{
    public class CourseInstructor
    {
        public int PersonID { get; set; }
        public Person person { get; set; }
        public int CourseID { get; set; }
        public Course course { get; set; }
    }
}
