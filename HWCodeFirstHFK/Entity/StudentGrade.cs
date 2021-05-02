using System;

namespace HWCodeFirstHFK.Entity
{
    public class StudentGrade
    {
        public int iD { get; set; }
        public int CourseID { get; set; }
        public int StudentID { get; set; }
        public Nullable<decimal> Grade { get; set; }

        public virtual Course Course { get; set; }
        public virtual Person Person { get; set; }
    }
}