﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LearnMVCBasics.Models
{
    public class SessionAttendee
    {
        public string Name { get; set; }
        public int ID { get; set; }
       
        public List <SessionAttendeeHours> Hours { get; set; }

    }
}