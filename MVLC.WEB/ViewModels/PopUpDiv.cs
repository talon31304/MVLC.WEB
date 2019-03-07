using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVLC.WEB.ViewModels
{
    public class PopUpDiv
    {
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string Content { get; set; }
        public int TimeOutSeconds { get; set; }
        public string CssClass { get; set; }
        public int id { get; set; }
        public int Next { get; set; }
        public int Previous { get; set; }
    }
}