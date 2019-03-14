using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVLC.DAL.Classes;
using MVLC.DAL.Models;

namespace MVLC.WEB.ViewModels
{
    public class HoursClassSelectViewModel
    {
        public DropDownDiv TermsDD { get; set; }
        public DropDownDiv TutorsDD { get; set; }
        public DropDownDiv ClassesDD { get; set; }
    }
}