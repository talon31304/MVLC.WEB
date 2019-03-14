using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVLC.DAL.Classes;

namespace MVLC.WEB.ViewModels
{
    public class HoursEntryViewModel
    {
        public List<string> Terms { get; set; }
        public List<SelectListItem> ActiveTutors { get; set; }

        public int? Year { get; set; }
        public int? Month { get; set; }


        public IEnumerable<SelectListItem> Years
        {
            get
            {
                return Enumerable.Range(2000, 12).Select(x => new SelectListItem
                {
                    Value = x.ToString(),
                    Text = x.ToString()
                });
            }
        }


        public int CurrentSession { get; set; }
        public string CurrentSessionDate { get; set; }
        public List<SessionAttendee> Students { get; set; }
        public List<SessionAttendee> Tutors { get; set; }
        public List<string> SessionDates { get; set; }
        public List<SessionAttendeeHours> AttendeeHours{ get; set; }



    }
}