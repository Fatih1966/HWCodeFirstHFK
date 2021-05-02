using System;
using System.Collections.Generic;
using System.Text;

namespace HWCodeFirstHFK.Entity
{
    public class Department
    {
        public int DepartmentID { get; set; }
        public string Name { get; set; }
        public decimal Budget { get; set; }
        public System.DateTime StartDate { get; set; }
        public Nullable<int> Administrator { get; set; }
        public virtual List<Course> Courses { get; set; }
    }
}
