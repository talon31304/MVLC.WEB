using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVLC.DAL.Models;

namespace MVLC.WEB.Controllers
{
    public class ClassController : Controller
    {
        private IClassRepository classRepository;

        public ClassController()
        {
            this.classRepository = new ClassRepository(new MVLCContext());
        }

        public ClassController(IClassRepository classRepository)
        {
            this.classRepository = classRepository;
        }




        // GET: Class
        public ActionResult AddHours()
        {
            return View();
        }
    }
}