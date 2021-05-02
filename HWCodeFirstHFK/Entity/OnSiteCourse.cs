using System;
using System.Collections.Generic;
using System.Text;

namespace HWCodeFirstHFK.Entity
{
    public class OnSiteCourse
    {
        public int iD { get; set; }
        public string Location { get; set; }
        public string Days { get; set; }
        public System.DateTime Time { get; set; }

        //public virtual Course Course { get; set; }
    }
}
