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
    public class ContentController : Controller
    {
        // GET: Content
        public ActionResult Get(int ID)
        {
            ContentRepository content = new ContentRepository();
            DynamicSectionContent DSC = content.Get(ID);
            DynamicDiv model = new DynamicDiv()
            {
                DivID = DSC.ContentID,
                HeaderLink = DSC.HeaderLink,
                Header = DSC.Header,
                Footer = DSC.Footer,
                CssClass = DSC.CssClass,
                Title = DSC.Title,
                SubTitle = DSC.SubTitle,
                BodyHTML = DSC.BodyHTML,
                NextContentID = DSC.NextContentID,
                PreviousContentID = DSC.PreviousContentID
            };

            return PartialView("DynamicDiv", model);
        }
    }
}