﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LearnMVCBasics.Models
{
    public class Session
    {
        public DateTime SessionDate { get; set; } 
        public List <SessionAttendeeHours> Attendees { get; set; }
    }
}