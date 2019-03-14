using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVLC.WEB.ViewModels.Session
{
    public class Session
    {
        public DateTime SessionDate { get; set; } 
        public List <SessionAttendeeHours> Attendees { get; set; }
    }
}