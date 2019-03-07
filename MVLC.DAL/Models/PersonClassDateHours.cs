using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVLC.DAL.Models
{
    public class PersonClassDateHours
    {
        public int ClassID { get; set; }
        public int PersonID { get; set; }
        public DateTime ClassDate { get; set; }
        public double Hours { get; set; }
       // public string stringDate { get; set; }
    }
}
