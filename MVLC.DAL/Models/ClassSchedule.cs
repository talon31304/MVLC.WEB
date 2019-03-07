using MVLC.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVLC.DAL.Classes
{
    class ClassSchedule
    {
        public int ClassID { get; set; }
        public string ClassName { get; set; }
        public string Location { get; set; }
        public string LocationID { get; set; }
        public string Term { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string ClassDays { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public List<NameID> Tutors { get; set; }
        public List<NameID> Students { get; set; }



    }
}
