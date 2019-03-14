using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVLC.WEB.App_Start
{
    public class AltRazorEngine : RazorViewEngine
    {
        
            public AltRazorEngine()
            {
                string[] locations = new string[] {
            "~/Views/{1}/{0}.cshtml",
            "~/Views/{1}/PartialViews/{0}.cshtml",
            "~/Views/Shared/{0}.cshtml",
            "~/Views/Shared/PartialViews/{0}.cshtml",
            "~/Views/Shared/Layouts/{0}.cshtml"
        };

                this.ViewLocationFormats = locations;
                this.PartialViewLocationFormats = locations;
                this.MasterLocationFormats = locations;
            }
        }


    
}