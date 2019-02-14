using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVLC.WEB.Models
{
    public class MultiSession
    {
        public int CurrentSession { get; set; }
        public string CurrentSessionDate { get; set; }
        //public IEnumerable <SelectListItem> TutorSelect
        public List<SessionAttendee> Students { get; set; }
        public List<SessionAttendee> Tutors { get; set; }
        public List<string> SessionDates { get; set; }
        public List<SessionAttendeeHours> AttendeeHours{ get; set; }
   
        //public List<float> AttendeeTotalHours { get; set; }
        //public List<string> AttendeeAttendance { get; set; }
    }
}