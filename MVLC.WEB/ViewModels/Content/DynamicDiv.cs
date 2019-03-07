using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVLC.WEB.ViewModels
{
    public class DynamicDiv
    {
        public int DivID { get; set; }
        public string HeaderLink { get; set; }
        public string Header { get; set; }
        public string Footer { get; set; }
        public string CssClass { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string BodyHTML { get; set; }
        public Nullable<int> NextContentID { get; set; }
        public Nullable<int> PreviousContentID { get; set; }
    }

}