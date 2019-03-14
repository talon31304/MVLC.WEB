using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVLC.DAL.Classes;
using MVLC.DAL.Models;

namespace MVLC.WEB.ViewModels
{
    public class HoursEntryViewModel
    {
        public DropDownDiv TermsDD { get; set; }
        public DropDownDiv TutorsDD { get; set; }
        public DropDownDiv ClassesDD { get; set; }

        public List<string> Terms { get; set; }
        public string selectedTerm { get; set; }

        public List<NameID> ActiveTutors { get; set; }
        public int selectedTutor { get; set; }

       
        public ParticipantsHoursEntryGrid EntryGrid { get; set; }



        //public List<NameID> Students { get; set; }
        //public List<NameID> Tutors { get; set; }
        //public List<PersonClassDateHours> Hours { get; set; }

        //public List<string> SessionDates { get; set; }


        public HoursEntryViewModel()
        {

        }
        

    }
}