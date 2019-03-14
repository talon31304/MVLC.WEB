using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVLC.DAL.Models;

namespace MVLC.WEB.Controllers
{
    public class ClassHoursController : Controller
    {
        private IClassHoursRepository classHoursRepository;
        private ITutorRepository tutorRepository;

        public ClassHoursController()
        {
            this.classHoursRepository = new ClassHoursRepository(new MVLCContext());
            this.tutorRepository = new TutorRepository(new MVLCContext());
        }

        public ClassHoursController(IClassHoursRepository classHoursRepository)
        {
            this.classHoursRepository = classHoursRepository;
        }

        // GET: Class
        public ActionResult Update()
        {
            TutorSelect model = classHoursRepository.GetByID(ClassID);

            return View(model);
        }

        // GET: Class
        public ActionResult Update(int ClassID)
        {
            ClassHours model = classHoursRepository.GetByID(ClassID);

            return View(model);
        }
    }
}