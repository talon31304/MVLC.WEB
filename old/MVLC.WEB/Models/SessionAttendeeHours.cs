﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVLC.WEB.Models
{
    public class SessionAttendeeHours
    {
        public string SessionDate { get; set; }
        public int AttendeeID { get; set; }
        public float Hours { get; set; }

    }
}