using MVLC.WEB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVLC.WEB.Controllers
{
    public class SessionController : Controller
    {
        // GET: Session
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Update()
            
        {
            MultiSession ClassSessionData = new MultiSession();
            ClassSessionData.SessionDates = new List<string>(new string[] { DateTime.Now.AddDays(-35).ToString("MMM dd, yyyy"), DateTime.Now.AddDays(-28).ToString("MMM dd, yyyy"), DateTime.Now.AddDays(-21).ToString("MMM dd, yyyy"), DateTime.Now.AddDays(-14).ToString("MMM dd, yyyy"), DateTime.Now.AddDays(-7).ToString("MMM dd, yyyy"), DateTime.Now.ToString("MMM dd, yyyy") });
            ClassSessionData.Students = new List<SessionAttendee>(new SessionAttendee[] { new SessionAttendee() {Name="Bugs Bunny",ID=1 }, new SessionAttendee() { Name = "Elmer Fudd", ID = 2 }, new SessionAttendee() { Name = "Daffy Duck", ID = 4 }, new SessionAttendee() { Name = "Road Runner", ID = 5 },new SessionAttendee() { Name = "Wiley Coyote", ID = 6 } });
            ClassSessionData.Tutors = new List<SessionAttendee>(new SessionAttendee[] { new SessionAttendee() { Name = "Rick Martel", ID = 100 }, new SessionAttendee() { Name = "Eliot Ness", ID = 101 } });
            //ClassSessionData.AttendeeHours = new List<SessionAttendeeHours>();
            int attendeeID = 1;

            foreach (var student in ClassSessionData.Students)
            {
                student.Hours= new List<SessionAttendeeHours>();
                student.Hours.Add(new SessionAttendeeHours() { AttendeeID = attendeeID, Hours = 2, SessionDate = DateTime.Now.AddDays(-35).ToString("MM/dd/yyyy") });
                student.Hours.Add(new SessionAttendeeHours() { AttendeeID = attendeeID, Hours = 2, SessionDate = DateTime.Now.AddDays(-28).ToString("MM/dd/yyyy") });
                student.Hours.Add(new SessionAttendeeHours() { AttendeeID = attendeeID, Hours = 2, SessionDate = DateTime.Now.AddDays(-21).ToString("MM/dd/yyyy") });
                student.Hours.Add(new SessionAttendeeHours() { AttendeeID = attendeeID, Hours = Math.Abs(attendeeID-3), SessionDate = DateTime.Now.AddDays(-14).ToString("MM/dd/yyyy") });
                student.Hours.Add(new SessionAttendeeHours() { AttendeeID = attendeeID, Hours = attendeeID +1, SessionDate = DateTime.Now.AddDays(-7).ToString("MM/dd/yyyy") });
                student.Hours.Add(new SessionAttendeeHours() { AttendeeID = attendeeID, Hours = 2, SessionDate = DateTime.Now.ToString("MM/dd/yyyy") });
                attendeeID++;
            }
            attendeeID = 100;
            foreach (var tutor in ClassSessionData.Students)
            {
                tutor.Hours = new List<SessionAttendeeHours>();
                tutor.Hours.Add(new SessionAttendeeHours() { AttendeeID = attendeeID, Hours = 2, SessionDate = DateTime.Now.AddDays(-35).ToString("MM/dd/yyyy") });
                tutor.Hours.Add(new SessionAttendeeHours() { AttendeeID = attendeeID, Hours = 2, SessionDate = DateTime.Now.AddDays(-28).ToString("MM/dd/yyyy") });
                tutor.Hours.Add(new SessionAttendeeHours() { AttendeeID = attendeeID, Hours = 2, SessionDate = DateTime.Now.AddDays(-21).ToString("MM/dd/yyyy") });
                tutor.Hours.Add(new SessionAttendeeHours() { AttendeeID = attendeeID, Hours = Math.Abs(attendeeID - 102), SessionDate = DateTime.Now.AddDays(-14).ToString("MM/dd/yyyy") });
                tutor.Hours.Add(new SessionAttendeeHours() { AttendeeID = attendeeID, Hours = attendeeID -99, SessionDate = DateTime.Now.AddDays(-7).ToString("MM/dd/yyyy") });
                tutor.Hours.Add(new SessionAttendeeHours() { AttendeeID = attendeeID, Hours = 2, SessionDate = DateTime.Now.ToString("MM/dd/yyyy") });
                attendeeID++;

            }
            ClassSessionData.CurrentSession = ClassSessionData.SessionDates.Count()-1;
            ClassSessionData.CurrentSessionDate = DateTime.Now.ToString("MM/dd/yyyy");
            // List<string> mylist = new List<string>(new string[] { "element1", "element2" });
            //Question q = new Question() { Text = "Some question" };

            return View(ClassSessionData);
        }
    }
}