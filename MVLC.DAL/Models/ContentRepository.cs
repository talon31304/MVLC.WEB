using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVLC.DAL.Entities;
using System.Data.Entity;
using MVLC.DAL.Models;

namespace MVLC.DAL.Classes
{
    public class ContentRepository
    {
        private MVLC_LIVE_Entities dbConn;
        
        public ContentRepository()
        {
            //dbConn = new MVLC_LIVE_Entities();
            //dbConn = new MVLC_LIVE_Entities();
            throw new KeyNotFoundException("Connection String Name Key must be specified.");

        }
        public ContentRepository(string ConnStringName)
        {
            if (ConnStringName != null && ConnStringName.Length > 0)
            {
                dbConn = new MVLC_LIVE_Entities(ConnStringName);
            }
            else
            {
                throw new KeyNotFoundException("Connection String Name Key must be specified.");
            }
        }
        public bool IsOnline()
        {
            try
            {
                int NumberofPeople = dbConn.People.Count();
                return (NumberofPeople > 1);
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public DynamicSectionContent Get(int ID)
        {

            return (
               from SL in dbConn.SectionLayouts
               join SC in dbConn.SectionContents on SL.SectionLayoutID equals SC.SectionLayoutID
               where SC.ContentID == ID
               select new DynamicSectionContent()
               {ContentID = SC.ContentID,
                   LayoutName = SL.LayoutName,
                   HeaderLink = SL.HeaderLink,
                   Header = SL.Header,
                   Footer = SL.Footer,
                   CssClass = SL.CssClass,

                   SectionLayoutID = SC.SectionLayoutID,
                   Title = SC.Title,
                   SubTitle = SC.SubTitle,
                   BodyHTML = SC.BodyHTML,
                   NextContentID = SC.NextContentID,
                   PreviousContentID = SC.PreviousContentID
               }
               )
               .First();
    }
  

        public List<string> GetCurrentTermsWithClassesEndingAfterLastWeek()
        {
            DateTime LastWeek = DateTime.Now.AddDays(-7);
            return (
                from c in dbConn.Classes
                    join t in dbConn.Terms on c.Term equals t.TermName
                where t.EndDate > LastWeek
                orderby t.StartDate descending
                    select c.Term
                    
                    ).Distinct().ToList();
        }
        public List<string> GetTermsWithClasses()
        {
                       return (from c in dbConn.Classes
                               join t in dbConn.Terms on c.Term equals t.TermName
                               orderby t.StartDate descending
                               select c.Term).Distinct().ToList();
        }
        public string GetCurrentOrNewestTerm()
        {
            DateTime AFewDaysAgo = DateTime.Today.AddDays(-2);
            DateTime AFewDaysFromNow = DateTime.Today.AddDays(+5);

            //try to get current term first
            string term = (from c in dbConn.Classes
                           join t in dbConn.Terms on c.Term equals t.TermName
                           where t.EndDate >= AFewDaysAgo && t.StartDate <= AFewDaysFromNow
                           select c.Term
                    ).Distinct().FirstOrDefault();
            //try to get latest available term
            if (term == null)
            {
                term = (from c in dbConn.Classes
                        join t in dbConn.Terms on c.Term equals t.TermName
                        orderby t.StartDate descending
                        select c.Term
                    ).Distinct().First();
            }
            return term;
            
        }

        public List<string> GetTermsWithClassesStartingAfterDate(DateTime CompareDate)
        {

                return (from c in dbConn.Classes
                        join t in dbConn.Terms on c.Term equals t.TermName
                        where t.StartDate > CompareDate
                        select c.Term
                        ).Distinct().ToList();
        }
        public List<NameID> GetTutorListByTerm(string Term)
        {

            return (
               from p in dbConn.People
               join pc in dbConn.PersonClasses on p.PersonID equals pc.PersonID
               join c in dbConn.Classes on pc.ClassID equals c.ClassID
               where pc.PersonRole == "T" && c.Term == Term
               select new NameID() { Name = p.Name, ID = p.PersonID.ToString() }).Distinct().ToList();

        }
        public List<NameID> GetTutorClassesByTutorPersonIDAndTerm(int PersonID, string Term)
        {

                return (
                               from p in dbConn.People
                               join pc in dbConn.PersonClasses on p.PersonID equals pc.PersonID
                               join c in dbConn.Classes on pc.ClassID equals c.ClassID
                               where pc.PersonRole == "T" && c.Term == Term && p.PersonID == PersonID
                               select new NameID() { Name = c.ClassName, ID = c.ClassID.ToString() }).ToList();
         
        }
        public List<DateTime> GetClassDatesByClassID(int ClassID)
        {
            throw new NotImplementedException();
                //return (from a in dbConn.ClassDates
                //        where a.ClassID == ClassID
                //        select a.Class_Date).ToList();
  
        }
        public List<DateTime> GetOnlyPastandPresentClassDatesByClassID(int ClassID)
        {
            DateTime today = DateTime.Today;
            return (from a in dbConn.ClassDates
                    where a.ClassID == ClassID && a.Class_Date<=today
                    select a.Class_Date).ToList();

        }
        public bool UpdatePersonClassHours(PersonClassDateHours hrs)
        {
            if (hrs != null &&
                hrs.ClassID > 0
                && hrs.ClassDate > DateTime.Now.AddDays(-3650)
                && hrs.ClassDate < DateTime.Now.AddDays(1)
                && hrs.Hours >= 0)
            {
                PersonClassHour pch = dbConn.PersonClassHours.FirstOrDefault(m => m.PersonID == hrs.PersonID && m.ClassID == hrs.ClassID && m.ClassDate == hrs.ClassDate);
                if (pch == null)
                {
                    pch = new PersonClassHour() { ClassID = hrs.ClassID, PersonID = hrs.PersonID, ClassDate = hrs.ClassDate, ClassHours = (double)hrs.Hours };
                    dbConn.PersonClassHours.Add(pch);
                }
                else
                {
                    pch.ClassHours = hrs.Hours;
                }

                dbConn.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }

        }
        public bool SetDidClassMeet (int ClassID,DateTime ClassDate, string DidClassMeet)
        {

            ClassDate meet = dbConn.ClassDates.FirstOrDefault(m => m.ClassID == ClassID && m.Class_Date == ClassDate);

                if (meet != null && DidClassMeet != null 
                    && (DidClassMeet=="Y"|| DidClassMeet == "N"))
                {
                    meet.DidClassMeet = DidClassMeet;
                    dbConn.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
                
            
        }
        public List<DateTime> ClassDatesWithNoClass(int ClassID)
        {

            return
                (from cd in dbConn.ClassDates
                         where cd.ClassID == ClassID && cd.DidClassMeet == "N"
                         select cd.Class_Date).ToList();


        }
        public List<DateTime> ClassDatesWithHoursOrNoClass(int ClassID)
        {
        
                return
                    ((from pch in dbConn.PersonClassHours
                     where pch.ClassID == ClassID && pch.ClassHours > 0
                     select pch.ClassDate).Distinct()
                     
                     .Union((from a in dbConn.ClassDates
                                 where a.ClassID == ClassID && a.DidClassMeet == "N"
                                 select a.Class_Date))
                     ).ToList();
           

        }
        public List<DateTime> ClassDatesWithHours (int ClassID)
        {
        
                return (from pch in dbConn.PersonClassHours
                        where pch.ClassID == ClassID && pch.ClassHours>0 
                        select pch.ClassDate).Distinct().ToList();
         

        }

        //PastClassDatesWithMissingHours
        //public List<DateTime> PastClassDatesWithMissingHours(int ClassID)
        //{
        //    //from p in dbConn.People
        //    //join pc in dbConn.PersonClasses on p.PersonID equals pc.PersonID
        //    //where pc.PersonRole == Role && pc.ClassID == ClassID
        //    //select new NameID() { Name = p.Name, ID = p.PersonID.ToString() }).ToList();


        //    using (var context = new MVLC_LIVE_Entities())
        //    {
        //        DateTime today = DateTime.Today;
        //        List<DateTime> classDates= (from a in context.ClassDates
        //                    where a.ClassID == ClassID && a.Class_Date < today
        //                             select a.Class_Date).ToList();
        //        foreach (DateTime dt in classDates)
        //        {
        //            if (!HoursExist)
        //        }


        //        //= GetClassDatesByClassIDBeforeDate(ClassID, DateTime.Today).ToList();

        //        return (from cd in context.ClassDates
        //                join pch in dbConn.PersonClassHours on cd.ClassID equals pch.ClassID
        //                into grpJoin
        //                from pat in grpJoin.DefaultIfEmpty()
        //                where cd.ClassID == ClassID && cd.DidClassMeet == "N"
        //                select cd.Class_Date).ToList();

        //    }
        //}

        public List<DateTime> GetDatesWithNoClassByClassID(int ClassID)
        {
         
                return (from a in dbConn.ClassDates
                        where a.ClassID == ClassID && a.DidClassMeet=="N"
                        select a.Class_Date).ToList();
           
        }

        public List<NameID> GetClassDatesByClassIDBeforeDate(int ClassID,DateTime compareDate)
        {

                return (from a in dbConn.ClassDates
                        where a.ClassID == ClassID && a.Class_Date<compareDate                        
                select new NameID() { Name = a.Class_Date.ToString(), ID = a.Class_Date.ToString() }).ToList();
   

        }
        public List<NameID> GetClassListByTerm(string Term)
        {

                return (from a in dbConn.Classes
                        where a.Term == Term
                        select new NameID() { ID = a.ClassID.ToString(), Name = a.ClassName }).ToList();
       
        }
        public List<NameID> GetTutorListByClassID(int ClassID)
        {

            return GetPersonListByClassIDandRole(ClassID, "T");


        }
        public List<NameID> GetPersonListByClassIDandRole(int ClassID, string Role)
        {

            return (
               from p in dbConn.People
               join pc in dbConn.PersonClasses on p.PersonID equals pc.PersonID
               where pc.PersonRole == Role && pc.ClassID == ClassID
               select new NameID() { Name = p.Name, ID = p.PersonID.ToString() }).ToList();
        }


        public List<PersonClassDateHours> GetHoursByClassID (int ClassID)
        {
            return (
                 from pch in dbConn.PersonClassHours
                 where pch.ClassID == ClassID 
                 select new PersonClassDateHours() { ClassID = pch.ClassID, PersonID = pch.PersonID, ClassDate=pch.ClassDate, Hours = (double)pch.ClassHours }).ToList();
        }

        public List<PersonClassDateHours> GetHoursByClassIDandRolexxx(int ClassID, string Role)
        {
            return (
                 from pch in dbConn.PersonClassHours
                 join pc in dbConn.PersonClasses on new { pch.PersonID, pch.ClassID } equals new { pc.PersonID, pc.ClassID }
                 where pch.ClassID == ClassID && pc.PersonRole==Role
                 select new PersonClassDateHours() { ClassID = pch.ClassID, PersonID = pch.PersonID, ClassDate = pch.ClassDate, Hours = (double)pch.ClassHours }).ToList();
        }
        public List<PersonClassDateHours> GetHoursByClassIDandRole(int ClassID, string Role)
        {
            return (
                from pch in dbConn.PersonClassHours 
                join pc in dbConn.PersonClasses on new { pch.PersonID, pch.ClassID } equals new { pc.PersonID, pc.ClassID }
                where pc.ClassID == ClassID && pc.PersonRole == Role
                select new PersonClassDateHours() { ClassID = pch.ClassID, PersonID = pch.PersonID, ClassDate =pch.ClassDate,  Hours = (double)pch.ClassHours }).ToList();
                                                                                         //PetName = subpet?.Name ?? String.Empty ///  Hours = xxx?.ClassHours ?? 0
                                                                                        // price = co?.price ?? 0,
                                                                            /// price = co == null ? 0 : (co.price ?? 0)
        }
        public List<PersonClassDateHours> GetHoursByPersonIDAndClassID(int ClassID, int PersonID)
        {
            return (
                 from pch in dbConn.PersonClassHours
                 where pch.ClassID == ClassID && pch.PersonID == PersonID
                 select new PersonClassDateHours() { ClassID = pch.ClassID, PersonID = pch.PersonID, ClassDate = pch.ClassDate, Hours = (double)pch.ClassHours }).ToList();
        }
        public List<PersonClassDateHours> GetHoursByDateAndClassID(int ClassID, DateTime ClassDate)
        {
            return (
                 from pch in dbConn.PersonClassHours
                 where pch.ClassID == ClassID && pch.ClassDate == ClassDate
                 select new PersonClassDateHours() { ClassID = pch.ClassID, PersonID = pch.PersonID, ClassDate = pch.ClassDate, Hours = (double)pch.ClassHours }).ToList();
        }
    }
}
