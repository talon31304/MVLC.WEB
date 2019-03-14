using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVLC.WEB.ViewModels.Session
{
    public class SessionAttendee
    {
        public string Name { get; set; }
        public int ID { get; set; }
        public double TotalHours { get; set; }
        public int ClassesAttended { get; set; }
        public List <SessionAttendeeHours> Hours { get; set; }

    }
}