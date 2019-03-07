using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVLC.WEB.ViewModels
{
    public class ParticipantsHoursEntryGrid
    {
        public List<DateTime> DatesClassDidNotMeet { get; set; }
        public List<DateTime> DatesWithNoHours { get; set; }
       
        public DateTime[] ClassDates { get; set; }
        public ParticipantHoursGridRow[] StudentRows { get; set; }
        public ParticipantHoursGridRow[] TutorRows { get; set; }
    }
}