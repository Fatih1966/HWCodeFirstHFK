using System;
using System.Collections.Generic;
using System.Text;

namespace HWCodeFirstHFK.Entity
{
    public class OfficeAssignment
    {
        public int iD { get; set; }
        public string Location { get; set; }
        public byte[] Timestamp { get; set; }
        public int PersonID { get; set; }
        public virtual Person Person { get; set; }
    }
}
