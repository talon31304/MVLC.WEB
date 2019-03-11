using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVLC.WEB.ViewModels;
using MVLC.DAL.Classes;
using MVLC.DAL.Models;

namespace MVLC.WEB.Controllers
{
    public class HoursController : Controller
    {
        public ActionResult Index()
        {
            var model = new MyViewModel();
            return View(model);
        }

        public ActionResult Months(int year)
        {
        
            if (year == 2011)
            {
                return Json(
                    Enumerable.Range(1, 3).Select(x => new { value = x, text = x }),
                    JsonRequestBehavior.AllowGet
                );
            }
            return Json(
                Enumerable.Range(1, 12).Select(x => new { value = x, text = x }),
                JsonRequestBehavior.AllowGet
            );
        }

        public ActionResult GetTermTutors(string Term)
        {
            HoursRepository hours = new HoursRepository();
            List<NameID> Tutors = hours.GetTutorListByTerm(Term);


            Tutors.Insert(0, new NameID() { Name = " (Select Tutor) ", ID = "-1" });
            return Json(
               Tutors,
               JsonRequestBehavior.AllowGet
           );

        }


        public ActionResult GetTermTutorClasses(int TutorID,string Term)
        {
            HoursRepository hours = new HoursRepository();
            return Json(
               hours.GetTutorClassesByTutorPersonIDAndTerm(TutorID, Term),
               JsonRequestBehavior.AllowGet
           );

        }
        public ActionResult GetTermTutorClassDates(int ClassID)
        {
            DateTime Tomorrow = DateTime.Now.AddDays(1);

            HoursRepository hours = new HoursRepository();
            List<NameID> classDates = hours.GetClassDatesByClassIDBeforeDate(ClassID, Tomorrow);

            List<NameID> classDateCleaned = (from dt in classDates
                                             select new NameID { Name = DateTime.Parse(dt.Name).ToString("MM/dd/yyyy"), ID = dt.ID }).ToList();
   



            return Json(
               classDateCleaned,
               JsonRequestBehavior.AllowGet
           );

        }

        public ActionResult GetClassHours(int ClassID)
        {
            ParticipantsHoursEntryGrid model = GetParticipantsHoursEntryGrid(ClassID);

            return Json(
              model,
              JsonRequestBehavior.AllowGet
          );
        }
        [HttpPost]
        public ActionResult SetClassHours(PersonClassDateHours hrs)
        {
            HoursRepository hours = new HoursRepository();

            bool result = hours.UpdatePersonClassHours(hrs);
        
            return Json(result,
              JsonRequestBehavior.AllowGet
          );
        }
        [HttpPost]
        public ActionResult SetDidClassMeet(int ClassID, DateTime ClassDate, string meet)
        {
            HoursRepository hours = new HoursRepository();

            bool result = hours.SetDidClassMeet(ClassID, ClassDate, meet);


            return Json(result,
              JsonRequestBehavior.AllowGet
          );
        }
        


        public HoursClassSelectViewModel GetHoursEntryViewModel(int ClassID)
        {
            HoursClassSelectViewModel model = new HoursClassSelectViewModel();
           // model.Students = new List<NameID>();

            return model;
        }


        private ParticipantHoursGridRow[] GetRowsForRole(DateTime[] classDates, int ClassID, string Role, int StartingRow)
        {
            HoursRepository hours = new HoursRepository();
            List<NameID> Participants = hours.GetPersonListByClassIDandRole(ClassID, Role);

            List<PersonClassDateHours> PersonHoursList = hours.GetHoursByClassIDandRole(ClassID, Role);
            

            DateTime currentDate; //This is only being used for clarity
          //  int currentPersonID;//This is only being used for clarity
            PersonClassDateHours currentPersonHours;

            ParticipantHoursGridRow[] rows = new ParticipantHoursGridRow[Participants.Count()];

            for (int row = 0; row < Participants.Count(); row++)
            {
               
                rows[row] = new ParticipantHoursGridRow();
                rows[row].IsLast = (row == (Participants.Count() - 1));

                rows[row].RowNumber = StartingRow + row;
                rows[row].ParticpantID = Int32.Parse(Participants[row].ID);
                rows[row].PartipantName = Participants[row].Name;
                rows[row].Hours = new DateHours[classDates.Length];
                rows[row].DataCells = new ParticipantsHoursGridCellContent[classDates.Length];
                for (int column = 0; column < classDates.Length; column++)
                {
                    
                    currentDate = classDates[column];
                    currentPersonHours = PersonHoursList.FirstOrDefault(a => a.PersonID == rows[row].ParticpantID && a.ClassID == ClassID && a.ClassDate == currentDate);
                    double hrsTemp = 0;
                    if (currentPersonHours == null || currentPersonHours.Hours <= 0)
                    {
                        hrsTemp = 0;
                    }
                    else
                    {
                        hrsTemp = currentPersonHours.Hours;
                    }
                    rows[row].DataCells[column] = new ParticipantsHoursGridCellContent()
                    {

                        Hours = hrsTemp,
                        DateString = currentDate.ToString("MM/dd/yyyy"),
                        Row = rows[row].RowNumber,
                        Column = column + 1,
                        ParticipantID = rows[row].ParticpantID

                    };
                    rows[row].Hours[column] = new DateHours() { Hours = 0, DateString = currentDate.ToString("MM/dd/yyyy") };

                }

            }
            return rows;
        }

        public ParticipantsHoursEntryGrid GetParticipantsHoursEntryGrid(int ClassID)
        {
            HoursRepository hours = new HoursRepository();
            
            ParticipantsHoursEntryGrid gridModel = new ParticipantsHoursEntryGrid();
            gridModel.ClassDates = hours.GetOnlyPastandPresentClassDatesByClassID(ClassID).OrderBy(d => d.Date).ToArray();

            // gridModel.DatesWithNoClass = hours.GetDatesWithNoClassByClassID(ClassID).OrderBy(d => d.Date).ToArray();
//            List<DateTime> GoodClasses = hours.ClassDatesWithHoursOrNoClass(ClassID);
            //List<DateTime> WithHours = hours.ClassDatesWithHours(ClassID);

            //gridModel.DatesClassDidNotMeet = hours.ClassDatesWithNoClass(ClassID);
            //gridModel.DatesWithNoHours =  new List<DateTime>();
            //foreach (DateTime dt in gridModel.ClassDates)
            //{
            //    if (!WithHours.Contains(dt))
            //    {
            //        gridModel.DatesWithNoHours.Add(dt);
            //    }
            //}

            gridModel.StudentRows = GetRowsForRole(gridModel.ClassDates, ClassID, "S",1);
            gridModel.TutorRows = GetRowsForRole(gridModel.ClassDates, ClassID, "T", gridModel.StudentRows.Count()+1);

            return gridModel;
        }

        public ActionResult GetClasses(int TutorID, string Term)
        {
            return PartialView("_HoursUpdatePartialView", 1);
        }

        public ActionResult GetTutorsByTerm(string p1)
        {
            string term = p1;
            bool isRefresh = true;
            string defaultValue = "-1"; //No selection made
            HoursRepository hours = new HoursRepository();
            List<NameID> ActiveTutors = hours.GetTutorListByTerm(term);
            ActiveTutors.Insert(0, new NameID() { Name = " (Select Tutor)", ID = defaultValue });
            DropDownDiv model = new DropDownDiv("TutorsDD", defaultValue, ActiveTutors, isRefresh, "ClassesDD", "ClassesChanged");
            return PartialView("_DropDownDivPartial", model);

        }


        public ActionResult GetClassesByTutorandTerm(string p1, string p2)
        {
            int tutorID = Int32.Parse(p1);
            string term = p2;

            bool isRefresh = true;
            string defaultValue = "-1"; //No selection made
            HoursRepository hours = new HoursRepository();
            List<NameID> ActiveClasses = hours.GetTutorClassesByTutorPersonIDAndTerm(tutorID, term);
            ActiveClasses.Insert(0, new NameID() { Name = " (Select Class)", ID = defaultValue });
            DropDownDiv model = new DropDownDiv("ClassesDD", defaultValue, ActiveClasses, isRefresh, "ClassesDD", "ClassesChanged");

            return PartialView("_DropDownDivPartial", model);

        }

        public ActionResult GetTutors(string term)
        {
            HoursRepository hours = new HoursRepository();
            List<NameID> ActiveTutors = hours.GetTutorListByTerm(term);
            ActiveTutors.Insert(0, new NameID() { Name = " (Select Tutor)", ID = "-1" });
            DropDownDiv model = new DropDownDiv("TutorsDD", "-1", ActiveTutors, false, "ClassesDD");
            return PartialView("_DropDownDivPartial", model);
        }
       


        public ActionResult Update(int id= -1)
        {
            if (id == -1) return SelectClass();

            ParticipantsHoursEntryGrid model = GetParticipantsHoursEntryGrid(id);

             List<string> choiceList = new List<string>() { "0", ".5", "1", "1.5", "2", "2.5", "3", "3.5", "4", "4.5", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20" };
            List<string> RadioVals = new List<string>() { "0", "1", "1.5", "2", "2.5" };

            HoursRepository hours = new HoursRepository();
            List<DateTime> WithHours = hours.ClassDatesWithHours(id);
            List<DateTime> ClassDates = hours.GetOnlyPastandPresentClassDatesByClassID(id).OrderBy(d => d.Date).ToList();

            List<DateTime> DatesClassDidNotMeet = hours.ClassDatesWithNoClass(id);
            List<DateTime> DatesWithNoHours = new List<DateTime>();
            foreach (DateTime dt in ClassDates)
            {
                if (!WithHours.Contains(dt))
                {
                    DatesWithNoHours.Add(dt);
                }
            }




            ViewData["Choices"] = choiceList;
            ViewData["DateColumns"] = model.ClassDates;
            ViewData["RadioButtonValues"] = RadioVals;
            ViewData["DatesClassDidNotMeet"] = DatesClassDidNotMeet;
            ViewData["DatesWithNoHours"] = DatesWithNoHours;

            return PartialView("_HoursUpdatePartialView", model);
        }



        private ActionResult SelectClass()

        {
            HoursClassSelectViewModel model = new HoursClassSelectViewModel();

            HoursRepository hours = new HoursRepository();
            string DropDownToCascadeTo;
            bool isRefresh = false;
            string refreshURL;

            DropDownToCascadeTo = "TutorsDD"; 
            string selectedTerm = hours.GetCurrentOrNewestTerm();
            List<string> termsToShow = hours.GetCurrentTermsWithClassesEndingAfterLastWeek();
            model.TermsDD = new DropDownDiv("TermsDD", selectedTerm, termsToShow, isRefresh, DropDownToCascadeTo, "ClassesChanged");

            DropDownToCascadeTo = "ClassesDD";
            refreshURL = this.Url.Action("GetTutorsByTerm", "Hours");
           List<NameID> tutorList = hours.GetTutorListByTerm(selectedTerm);
            string defaultTutorID = "-1";
            tutorList.Insert(0, new NameID() { Name = " (Select Tutor)", ID = defaultTutorID });
            model.TutorsDD = new DropDownDiv("TutorsDD", defaultTutorID, tutorList, isRefresh, DropDownToCascadeTo, "ClassesChanged", refreshUrl: refreshURL);

            DropDownToCascadeTo = "";
            refreshURL = this.Url.Action("GetClassesByTutorandTerm", "Hours");
            List<NameID> classList = new List<NameID>();
            string defaultClassID = "-1";
            classList.Insert(0, new NameID() { Name = " (Select Class)", ID = defaultClassID });
            model.ClassesDD = new DropDownDiv("ClassesDD", defaultClassID, classList, isRefresh, DropDownToCascadeTo, "ClassesChanged", refreshUrl: refreshURL);

 
            return View(model);

        }
    }
}