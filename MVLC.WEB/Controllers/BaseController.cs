using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVLC.WEB.ViewModels;
using MVLC.DAL.Classes;
using MVLC.DAL.Models;
using System.Web.Configuration;
using System.Configuration;
using System.Data.SqlClient;

namespace MVLC.WEB.Controllers
{
    public class BaseController : Controller
    {
        protected bool IsDBavailable()
        {
            ContentRepository cr = new ContentRepository(ConnStringName);
            return cr.IsOnline();
        }
        protected ActionResult NoDatabaseAvailable ()
        {
            if (!IsDBavailable())
            {
                ViewBag.MessageTitle = "Database Unavailable";
                return View(viewName: "Message", model: "Database is Not Available, please try again later.");
            }
            return null;

        }


        //protected override void OnActionExecuting(ActionExecutingContext context)
        //{
        //    ContentRepository cr = new ContentRepository(ConnStringName);

        //    //ViewBag.DBStatus = (cr.IsOnline() ? "Online" : "Offline");
        //}

        //string userName = WebConfigurationManager.AppSettings["PFUserName"];
        protected string ConnStringName = WebConfigurationManager.AppSettings["ConnectionStringName"];
                

        public ActionResult ShowEnvironmentInfo()
        {

            ContentRepository cr = new ContentRepository(ConnStringName);

            EnvironmentInfo model = new EnvironmentInfo();

            model.CurrentStatus = (cr.IsOnline() ? "Online" : "Offline");
          model.EnvironmentType =  (string)System.Web.HttpContext.Current.Application["EnvironmentType"];
            model.DataSource = (string)System.Web.HttpContext.Current.Application["DataSource"];
            model.DB = (string)System.Web.HttpContext.Current.Application["DB"];


            return PartialView("_EnvironmentData", model);

        }

    }
}